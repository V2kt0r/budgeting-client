using Budgeting.ViewModels;

namespace Budgeting.Views
{
    public partial class GroupPage : ContentPage
    {
    	private readonly GroupPageViewModel _viewModel;

    	public GroupPage(GroupPageViewModel viewModel)
    	{
    		InitializeComponent();
    		_viewModel = viewModel;
    		BindingContext = _viewModel;
    	}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
    		await _viewModel.OnAppearingAsync();
        }

        private async void GroupPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            await _viewModel.OnGroupChangedAsync();
        }

        private async void CurrencyPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            await _viewModel.OnCurrencyChangedAsync();
        }
    }
}