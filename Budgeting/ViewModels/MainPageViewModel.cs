using Budgeting.Contracts.Services;
using Budgeting.Shells;
using Budgeting.ViewModels.Base;
using Budgeting.ViewModels.Popups;
using Budgeting.Views;
using Budgeting.Views.Popups;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;
using System.Diagnostics;

namespace Budgeting.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {
        #region Attributes

        private readonly INavigationService _navigationService;
        private readonly IAuthService _authService;
        private readonly Config.Config _config;
        private readonly IPopupService _popupService;

        [ObservableProperty]
        private IEnumerable<TransactionRead> _transactions;

        [ObservableProperty]
        private int _page = 1;

        [ObservableProperty]
        private bool _finishedLoadingTransactions = false;

        #endregion

        #region Properties

        public IRelayCommand LogoutCommand => new AsyncRelayCommand(OnLogoutAsync);
        public IRelayCommand TransactionSelectedCommand => new AsyncRelayCommand<TransactionRead>(OnTransactionSelectedAsync);
        public IRelayCommand AddTransactionCommand => new AsyncRelayCommand(OnAddTransactionAsync);

        #endregion

        #region Constructor

        public MainPageViewModel(INavigationService navigationService, IAuthService authService, Config.Config config, IPopupService popupService)
        {
            _navigationService = navigationService;
            _authService = authService;
            _config = config;
            _popupService = popupService;
        }

        #endregion

        #region Public Methods

        public async Task OnAppearingAsync()
        {
            await LoadTransactionsAsync();
        }

        #endregion

        #region Private Methods

        private async Task LoadTransactionsAsync()
        {
            FinishedLoadingTransactions = false;

            try
            {
                var transactionsPaginated = await new TransactionsApi(_config.Configuration).GetUserTransactionsAsync(page: Page);
                Transactions = transactionsPaginated.Data;
            }
            catch (ApiException apiEx)
            {
                Debug.WriteLine(apiEx);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            FinishedLoadingTransactions = true;
        }

        private async Task OnLogoutAsync()
        {
            await _authService.LogoutAsync();
            //await Shell.Current.GoToAsync($"///{nameof(LoginPage)}");
            Application.Current.MainPage = IPlatformApplication.Current.Services.GetService<UnauthorizedAppShell>();
        }

        private async Task OnTransactionSelectedAsync(TransactionRead transaction)
        {
            var navigationParameters = new Dictionary<string, object>
            {
                { "Transaction", transaction }
            };
            await Shell.Current.GoToAsync($"{nameof(TransactionDetailPage)}", parameters: navigationParameters);
        }

        private async Task OnAddTransactionAsync()
        {
            //await Shell.Current.CurrentPage.ShowPopupAsync(addTransactionPopup);
            Debug.WriteLine("Showing popup");
            var result = await _popupService.ShowPopupAsync<AddTransactionPopupViewModel>();
        }

        #endregion
    }
}
