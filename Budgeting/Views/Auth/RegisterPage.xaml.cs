using Budgeting.ViewModels.Auth;

namespace Budgeting.Views
{
    public partial class RegisterPage : ContentPage
    {
    	private readonly RegisterPageViewModel _viewModel;

    	public RegisterPage(RegisterPageViewModel viewModel)
    	{
    		InitializeComponent();
    		_viewModel = viewModel;
    		BindingContext = _viewModel;
    	}
    }
}