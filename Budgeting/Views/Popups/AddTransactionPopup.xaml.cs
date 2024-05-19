using Budgeting.ViewModels.Popups;
using CommunityToolkit.Maui.Views;

namespace Budgeting.Views.Popups
{
    public partial class AddTransactionPopup : Popup
    {
        private readonly AddTransactionPopupViewModel _viewModel;

        public AddTransactionPopup(AddTransactionPopupViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }
    }
}