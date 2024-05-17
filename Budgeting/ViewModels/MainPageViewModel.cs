using Budgeting.Contracts.Services;
using Budgeting.Shells;
using Budgeting.ViewModels.Base;
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

        #endregion

        #region Constructor

        public MainPageViewModel(INavigationService navigationService, IAuthService authService, Config.Config config)
        {
            _navigationService = navigationService;
            _authService = authService;
            _config = config;
        }

        #endregion

        #region Public Methods

        public async Task OnAppearingAsync()
        {
            await LoadTransactionsAsync();
        }

        #endregion

        #region Private Methods

        private async Task OnLogoutAsync()
        {
            await _authService.LogoutAsync();
            //await Shell.Current.GoToAsync($"///{nameof(LoginPage)}");
            Application.Current.MainPage = IPlatformApplication.Current.Services.GetService<UnauthorizedAppShell>();
        }

        private async Task OnTransactionSelectedAsync(TransactionRead transaction)
        {
            throw new NotImplementedException();
        }

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

        #endregion
    }
}
