using Budgeting.Contracts.Services;
using Budgeting.ViewModels.Base;
using Budgeting.Views;
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
            Debug.WriteLine("SplashLoadPageViewModel.OnAppearing");
            await InitializeAsync();
        }

        #endregion

        #region Private Methods

        private async Task InitializeAsync()
        {
            Debug.WriteLine("SplashLoadPageViewModel.InitializeAsync");
            var loginSuccessful = await _authService.LoginWithTokenAsync();
            Debug.WriteLine("SplashLoadPageViewModel.InitializeAsync: loginSuccessful = " + loginSuccessful);
            if (loginSuccessful)
            {
                Debug.WriteLine("SplashLoadPageViewModel.InitializeAsync: Navigating to MainPage");
                await _navigationService.NavigateToPageAsync<MainPage>();
            }
            else
            {
                Debug.WriteLine("SplashLoadPageViewModel.InitializeAsync: Navigating to LoginPage");
                await _navigationService.NavigateToPageAsync<LoginPage>();
            }
        }

        #endregion
    }
}
