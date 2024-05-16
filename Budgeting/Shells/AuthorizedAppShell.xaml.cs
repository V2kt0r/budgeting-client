using Budgeting.ViewModels.Shells;
using Budgeting.Views;

namespace Budgeting.Shells
{
    public partial class AuthorizedAppShell : Shell
    {
        private readonly AuthorizedAppShellViewModel _viewModel;

        public AuthorizedAppShell()
        {
            InitializeComponent();
            _viewModel = IPlatformApplication.Current.Services.GetService<AuthorizedAppShellViewModel>();
            BindingContext = _viewModel;

            // Register routes for the view models
            Routing.RegisterRoute("MainPage", typeof(MainPage));
        }
    }
}
