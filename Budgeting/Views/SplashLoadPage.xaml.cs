using Budgeting.ViewModels;

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

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.OnAppearingAsync();
        }
    }
}