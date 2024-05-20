using Budgeting.Contracts.Services;
using Budgeting.Controls;
using Budgeting.Shells;
using Budgeting.ViewModels.Base;
using Budgeting.ViewModels.Popups;
using Budgeting.Views;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microcharts;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;
using SkiaSharp;
using System.Collections.ObjectModel;
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

        [ObservableProperty]
        private bool _finishedLoadingStatistics = false;

        [ObservableProperty]
        private IEnumerable<TimeQueryWrapper> _afterPossibilities = new ObservableCollection<TimeQueryWrapper>()
        {
            new() {Time = DateTime.UtcNow - TimeSpan.FromDays(1), Title = "Last day"},
            new() {Time = DateTime.UtcNow - TimeSpan.FromDays(7), Title = "Last 7 days"},
            new() {Time = DateTime.UtcNow - TimeSpan.FromDays(30), Title = "Last month"},
            new() {Time = DateTime.UtcNow - TimeSpan.FromDays(365), Title = "Last year"},
            new() {Time = null, Title = "All time"}
        };

        [ObservableProperty]
        private TimeQueryWrapper _after;

        [ObservableProperty]
        private PurchaseCategoryStatistics _purchaseCategoryStatistics;

        [ObservableProperty]
        private ChartEntry[] _entries;

        [ObservableProperty]
        private DonutChart _donutChart;

        #endregion

        #region Properties

        public IRelayCommand LogoutCommand => new AsyncRelayCommand(OnLogoutAsync);
        public IRelayCommand TimeSelectionChangedCommand => new AsyncRelayCommand<DateTime?>(OnTimeSelectionChangedAsync);
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

            After = AfterPossibilities.Last();
        }

        #endregion

        #region Public Methods

        public async Task OnAppearingAsync()
        {
            await LoadTransactionsAsync();
            await LoadStatisticsAsync(After.Time);
        }

        public async Task LoadStatisticsAsync(DateTime? after)
        {
            FinishedLoadingStatistics = false;

            try
            {
                PurchaseCategoryStatistics = await new UserStatisticsApi(_config.Configuration).GetPurchaseCategoryStatisticsAsync(after: after);
                var chartEntries = new List<ChartEntry>();
                foreach (var item in PurchaseCategoryStatistics.Items)
                {
                    var chartEnty = new ChartEntry((float)item.Total)
                    {
                        Label = item.PurchaseCategory.CategoryName,
                        ValueLabel = item.Total.ToString(),
                        ValueLabelColor = SKColors.White,
                        Color = SKColor.Parse($"#{item.PurchaseCategory.Uuid.ToString().Substring(0, 6)}")
                    };
                    chartEntries.Add(chartEnty);
                }
                Entries = chartEntries.ToArray();
                DonutChart = new DonutChart
                {
                    Entries = Entries,
                    BackgroundColor = SKColors.Transparent
                };
            }
            catch (ApiException apiEx)
            {
                Debug.WriteLine(apiEx.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            FinishedLoadingStatistics = true;
        }

        #endregion

        #region Private Methods

        private async Task OnTimeSelectionChangedAsync(DateTime? newTime)
        {
            await LoadStatisticsAsync(newTime);
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
                Debug.WriteLine(apiEx.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            FinishedLoadingTransactions = true;
        }

        private async Task OnLogoutAsync()
        {
            await _authService.LogoutAsync();
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
            Debug.WriteLine("Showing popup");
            var result = await _popupService.ShowPopupAsync<AddTransactionPopupViewModel>();
            await LoadTransactionsAsync();
        }

        #endregion
    }
}
