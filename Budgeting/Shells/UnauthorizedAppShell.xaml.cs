using Budgeting.ViewModels.Shells;
using Budgeting.Views;

namespace Budgeting.Shells
{
    public partial class UnauthorizedAppShell : Shell
    {
        private readonly UnauthorizedAppShellViewModel _viewModel;

        public UnauthorizedAppShell()
        {
            InitializeComponent();
            _viewModel = IPlatformApplication.Current.Services.GetService<UnauthorizedAppShellViewModel>();
            BindingContext = _viewModel;

            // Register routes for the view models
            Routing.RegisterRoute("SplashLoadPage", typeof(SplashLoadPage));
            Routing.RegisterRoute("LoginPage", typeof(LoginPage));
            Routing.RegisterRoute("RegisterPage", typeof(RegisterPage));
        }
    }
}
