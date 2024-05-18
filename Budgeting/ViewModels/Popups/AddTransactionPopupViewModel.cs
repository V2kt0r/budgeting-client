using Budgeting.ViewModels.Base;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Org.OpenAPITools.Model;

namespace Budgeting.ViewModels.Popups
{
    public partial class AddTransactionPopupViewModel : ViewModelBase
    {
        #region Attributes

        private readonly Config.Config _config;

        [ObservableProperty]
        private TransactionCreate _transactionCreate;

        [ObservableProperty]
        private DateTime _date;

        [ObservableProperty]
        private TimeSpan _time;

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
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private async Task OnOkAsync(object obj)
        {
            if (obj is Popup popup)
            {
                await popup.CloseAsync();
            }
        }

        private void UpdateTimestamp()
        {
            DateTime timestamp = new(
                year: Date.Year,
                month: Date.Month,
                day: Date.Day,
                hour: Time.Hours,
                minute: Time.Minutes,
                second: Time.Seconds
            );
            TransactionCreate.Timestamp = timestamp;
        }

        #endregion
    }
}
