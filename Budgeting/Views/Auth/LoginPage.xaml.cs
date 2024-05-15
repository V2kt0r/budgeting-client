using Budgeting.ViewModels.Auth;

namespace Budgeting.Views
{
    public partial class LoginPage : ContentPage
    {
    	private readonly LoginPageViewModel _viewModel;

    	public LoginPage(LoginPageViewModel viewModel)
    	{
    		InitializeComponent();
    		_viewModel = viewModel;
    		BindingContext = _viewModel;
    	}
    }
}