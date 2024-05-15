using Budgeting.Contracts.Services;
using Budgeting.ViewModels.Auth;
using Budgeting.ViewModels.Base;
using Budgeting.Views;
using CommunityToolkit.Mvvm.Input;

namespace Budgeting.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {
        #region Attributes

        private readonly INavigationService _navigationService;
        private readonly IAuthService _authService;

        #endregion

        #region Properties

        public IRelayCommand LogoutCommand => new RelayCommand(OnLogout);

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

        private void OnLogout()
        {
            _navigationService.SetAsHomePage(new LoginPage(new LoginPageViewModel(_navigationService, _authService)));
        }

        #endregion
    }
}
