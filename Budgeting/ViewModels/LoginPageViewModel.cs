using Budgeting.Contracts.Services;
using Budgeting.ViewModels.Base;
using Budgeting.Views;
using CommunityToolkit.Mvvm.Input;

namespace Budgeting.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        #region Attributes

        private readonly INavigationService _navigationService;

        #endregion

        #region Properties

        public IRelayCommand LoginCommand => new AsyncRelayCommand(OnLoginAsync);
        public IRelayCommand RegisterCommand => new AsyncRelayCommand(OnRegisterAsync);

        #endregion

        #region Constructor

        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private async Task OnLoginAsync()
        {
            await _navigationService.NavigateToPageAsync<MainPage>();
        }

        private async Task OnRegisterAsync()
        {
            await _navigationService.NavigateToPageAsync<RegisterPage>();
        }

        #endregion
    }
}
