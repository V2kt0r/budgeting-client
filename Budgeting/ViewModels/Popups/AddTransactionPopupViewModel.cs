using Budgeting.Controls;
using Budgeting.Utils;
using Budgeting.ViewModels.Base;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Budgeting.ViewModels.Popups
{
    public partial class AddTransactionPopupViewModel : ViewModelBase
    {
        #region Attributes

        private readonly Config.Config _config;

        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private string _description = string.Empty;

        [ObservableProperty]
        private decimal? _amount = null;

        [ObservableProperty]
        private Currency _currency = Currency.HUF;

        [ObservableProperty]
        private ObservableCollection<TransactionItemCreate> _transactionItems = new();

        [ObservableProperty]
        private TransactionItemCreateInternal _lastItem;

        [ObservableProperty]
        private TransactionCreate _transactionCreate;

        [ObservableProperty]
        private NotifyTaskCompletion<IEnumerable<PurchaseCategoryRead>> _purchaseCategories;

        [ObservableProperty]
        private DateTime _date = DateTime.Now;

        [ObservableProperty]
        private TimeSpan _time = DateTime.Now.TimeOfDay;

        [ObservableProperty]
        private IEnumerable<Currency> _currencyOptions = Enum.GetValues(typeof(Currency)).Cast<Currency>();

        #endregion

        #region Properties

        public IRelayCommand<object> OkCommand => new AsyncRelayCommand<object>(OnOkAsync);

        #endregion

        #region Constructor

        public AddTransactionPopupViewModel(Config.Config config)
        {
            _config = config;
            PurchaseCategories = new NotifyTaskCompletion<IEnumerable<PurchaseCategoryRead>>(FetchPurchaseCategoriesAsync());
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private async Task OnOkAsync(object obj)
        {
            if (obj is Popup popup)
            {
                bool added = false;
                try
                {
                    if (LastItem.IsValid())
                    {
                        TransactionItems.Add(LastItem.ToTransactionItemCreate());
                        added = true;
                    }
                    TransactionCreate = new TransactionCreate
                    (
                        name: Name,
                        description: Description,
                        amount: Amount.Value,
                        currency: Currency,
                        timestamp: GetTimestamp(),
                        transactionItems: TransactionItems.ToList()
                    );
                    var result = await new TransactionsApi(_config.Configuration).CreateUserTransactionAsync(TransactionCreate);

                    await Toaster.DisplayLongToastAsync($"Added transaction '{result.Name}' with {result.TransactionItems.Count} items.");
                    await popup.CloseAsync();
                }
                catch (ApiException apiEx)
                {
                    await Toaster.DisplayLongToastAsync($"API error during adding transaction: {apiEx.Message}");
                    Debug.WriteLine(apiEx.Message);
                }
                catch (Exception ex)
                {
                    await Toaster.DisplayLongToastAsync($"Error during adding transaction: {ex.Message}");
                    Debug.WriteLine(ex.Message);
                    throw;
                }
                finally
                {
                    if (added)
                    {
                        TransactionItems.RemoveAt(TransactionItems.Count - 1);
                    }
                }
            }
        }

        private DateTime GetTimestamp()
        {
            return new DateTime(
                year: Date.Year,
                month: Date.Month,
                day: Date.Day,
                hour: Time.Hours,
                minute: Time.Minutes,
                second: Time.Seconds
            );
        }

        private async Task<IEnumerable<PurchaseCategoryRead>> FetchPurchaseCategoriesAsync()
        {
            var result = await new UserPurchaseCategoryApi(_config.Configuration).GetPurchaseCategoriesAsync();
            return result.Data;
        }

        #endregion
    }
}
