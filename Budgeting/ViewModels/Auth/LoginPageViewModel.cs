using Budgeting.Contracts.Services;
using Budgeting.ViewModels.Base;
using Budgeting.Views;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace Budgeting.ViewModels.Auth
{
    public class LoginPageViewModel : ViewModelBase
    {
        #region Attributes

        private readonly INavigationService _navigationService;
        private readonly IAuthService _authService;

        #endregion

        #region Properties

        public IRelayCommand LoginCommand => new AsyncRelayCommand(OnLoginAsync);
        public IRelayCommand RegisterCommand => new AsyncRelayCommand(OnRegisterAsync);
        public string UsernameEntry { get; set; } = string.Empty;
        public string PasswordEntry { get; set; } = string.Empty;

        #endregion

        #region Constructor

        public LoginPageViewModel(INavigationService navigationService, IAuthService authService)
        {
            _navigationService = navigationService;
            _authService = authService;
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private async Task OnLoginAsync()
        {
            var username = UsernameEntry.Trim();
            var password = PasswordEntry.Trim();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return;
            }

            var loginSuccess = await _authService.LoginWithCredentialsAsync(username, password);
            if (!loginSuccess)
            {
                return;
            }

            await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
        }

        private async Task OnRegisterAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
        }

        #endregion
    }
}
