﻿using Budgeting.Contracts.Services;
using Budgeting.Shells;
using Budgeting.ViewModels.Base;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Budgeting.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {
        #region Attributes

        private readonly INavigationService _navigationService;
        private readonly IAuthService _authService;

        #endregion

        #region Properties

        public IRelayCommand LogoutCommand => new AsyncRelayCommand(OnLogoutAsync);

        #endregion

        #region Constructor

        public MainPageViewModel(INavigationService navigationService, IAuthService authService)
        {
            _navigationService = navigationService;
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
