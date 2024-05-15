using Budgeting.Contracts.Services;
using Budgeting.ViewModels.Auth;
using Budgeting.Views;

namespace Budgeting
{
    public partial class App : Application
    {
        public App(SplashLoadPageViewModel splashLoadPageViewModel)
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new SplashLoadPage(splashLoadPageViewModel);
        }
    }
}
