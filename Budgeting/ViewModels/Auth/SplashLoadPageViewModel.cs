using Budgeting.Contracts.Services;
using Budgeting.Shells;
using Budgeting.ViewModels.Base;
using Budgeting.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Budgeting.ViewModels.Auth
{
    public class SplashLoadPageViewModel : ViewModelBase
    {
        #region Attributes

        private readonly INavigationService _navigationService;
        private readonly IAuthService _authService;

        #endregion

        #region Constructor

        public SplashLoadPageViewModel(INavigationService navigationService, IAuthService authService)
        {
            _navigationService = navigationService;
            _authService = authService;
        }

        #endregion

        #region Public Methods

        public async Task OnAppearingAsync()
        {
            await InitializeAsync();
        }

        #endregion

        #region Private Methods

        private async Task InitializeAsync()
        {
            var loginSuccessful = await _authService.LoginWithTokenAsync();
            if (loginSuccessful)
            {
                //await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
                Application.Current.MainPage = IPlatformApplication.Current.Services.GetService<AuthorizedAppShell>();
            }
            else
            {
                await Shell.Current.GoToAsync($"///{nameof(LoginPage)}");
            }
        }

        #endregion
    }
}
