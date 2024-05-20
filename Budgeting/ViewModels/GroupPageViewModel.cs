using Budgeting.Contracts.Services;
using Budgeting.Controls;
using Budgeting.ViewModels.Base;
using Budgeting.Views;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Extensions;
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
    public partial class GroupPageViewModel : ViewModelBase
    {
        #region Attributes

        private readonly IAuthService _authService;
        private readonly Config.Config _config;
        private readonly IPopupService _popupService;

        [ObservableProperty]
        private ObservableCollection<GroupReadWithUserRole> _groups;

        [ObservableProperty]
        private GroupReadWithUserRole _selectedGroup;

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
        private bool _finishedLoadingStatistics = false;

        [ObservableProperty]
        private PurchaseCategoryStatistics _purchaseCategoryStatistics;

        [ObservableProperty]
        private ChartEntry[] _entries;

        [ObservableProperty]
        private DonutChart _donutChart;

        [ObservableProperty]
        private IEnumerable<TransactionRead> _transactions;

        [ObservableProperty]
        private int _page = 1;

        [ObservableProperty]
        private bool _finishedLoadingTransactions = false;

        #endregion

        #region Properties

        public IRelayCommand AddTransactionCommand => new AsyncRelayCommand(OnAddTransactionAsync);
        public IRelayCommand TimeSelectionChangedCommand => new AsyncRelayCommand<DateTime?>(OnTimeSelectionChanged);
        public IRelayCommand TransactionSelectedCommand => new AsyncRelayCommand<TransactionRead>(OnTransactionSelectedAsync);

        #endregion

        #region Constructor

        public GroupPageViewModel(IAuthService authService, Config.Config config, IPopupService popupService)
        {
            _authService = authService;
            _config = config;
            _popupService = popupService;

            After = AfterPossibilities.Last();
        }

        #endregion

        #region Public Methods

        public async Task OnAppearingAsync()
        {
            await LoadUserGroups();
            SelectedGroup = Groups.FirstOrDefault(defaultValue: null);
            await LoadStatisticsAsync(After.Time);
        }

        #endregion

        #region Private Methods

        private async Task LoadUserGroups()
        {
            var result = await new GroupApi(_config.Configuration).GetGroupsAsync();
            Groups = result.Data.ToObservableCollection();
        }

        private async Task OnAddTransactionAsync()
        {
            throw new NotImplementedException();
        }

        private async Task OnTimeSelectionChanged(DateTime? newTime)
        {
            await LoadStatisticsAsync(newTime);
        }

        private async Task LoadStatisticsAsync(DateTime? after)
        {
            FinishedLoadingStatistics = false;

            try
            {
                return;
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

            // TODO: remove the comment after function has been properly implemented
            //FinishedLoadingStatistics = true;
        }

        private async Task OnTransactionSelectedAsync(TransactionRead transaction)
        {
            var navigationParameters = new Dictionary<string, object>
            {
                { "Transaction", transaction }
            };
            await Shell.Current.GoToAsync($"{nameof(TransactionDetailPage)}", parameters: navigationParameters);
        }

        #endregion
    }
}
