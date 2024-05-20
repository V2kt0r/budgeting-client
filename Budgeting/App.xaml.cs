using Budgeting.Shells;

namespace Budgeting
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new UnauthorizedAppShell();
        }
    }
}
