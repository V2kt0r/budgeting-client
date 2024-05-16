using Budgeting.Contracts.Services;
using Budgeting.Shells;
using Budgeting.ViewModels.Base;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Budgeting.ViewModels.Shells
{
    public class AuthorizedAppShellViewModel : ViewModelBase
    {
        #region Attributes

        private readonly IAuthService _authService;

        #endregion

        #region Properties

        public IAuthService AuthService => _authService;
        public IRelayCommand LogoutCommand => new AsyncRelayCommand(OnLogoutAsync);

        #endregion

        #region Constructor

        public AuthorizedAppShellViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private async Task OnLogoutAsync()
        {
            await _authService.LogoutAsync();
            //await Shell.Current.GoToAsync($"///{nameof(LoginPage)}");
            Application.Current.MainPage = IPlatformApplication.Current.Services.GetService<UnauthorizedAppShell>();
        }

        #endregion
    }
}
