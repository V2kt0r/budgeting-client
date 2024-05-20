using Budgeting.ViewModels.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Org.OpenAPITools.Model;

namespace Budgeting.ViewModels
{
    [QueryProperty(nameof(Transaction), "Transaction")]
    public partial class TransactionDetailPageViewModel : ViewModelBase
    {
        #region Attributes

        private readonly Config.Config _config;

        [ObservableProperty]
        private TransactionRead _transaction;

        #endregion

        #region Properties

        public IRelayCommand TransactionItemSelectedCommand => new AsyncRelayCommand<TransactionItemRead>(OnTransactionItemSelectedAsync);
        public IRelayCommand AddTransactionItemCommand => new AsyncRelayCommand<TransactionRead>(OnAddTransactionItemAsync);

        #endregion

        #region Constructor

        public TransactionDetailPageViewModel(Config.Config config)
        {
            _config = config;
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private async Task OnTransactionItemSelectedAsync(TransactionItemRead transactionItem)
        {
            throw new NotImplementedException();
        }

        private async Task OnAddTransactionItemAsync(TransactionRead transaction)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
