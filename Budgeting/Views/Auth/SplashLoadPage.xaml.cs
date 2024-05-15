using Budgeting.ViewModels.Auth;

namespace Budgeting.Views
{
    public partial class SplashLoadPage : ContentPage
    {
    	private readonly SplashLoadPageViewModel _viewModel;

    	public SplashLoadPage(SplashLoadPageViewModel viewModel)
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