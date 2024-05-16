using Budgeting.Contracts.Services;
using Budgeting.ViewModels.Auth;
using Budgeting.Views;

namespace Budgeting
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
