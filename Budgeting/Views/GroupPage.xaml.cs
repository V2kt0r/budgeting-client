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
    }
}