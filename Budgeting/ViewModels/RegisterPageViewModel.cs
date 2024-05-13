using Budgeting.Contracts.Services;
using Budgeting.ViewModels.Base;
using CommunityToolkit.Mvvm.Input;

namespace Budgeting.ViewModels
{
    public class RegisterPageViewModel : ViewModelBase
    {
        #region Attributes

        private readonly INavigationService _navigationService;

        #endregion

        #region Properties

        public IRelayCommand RegisterCommand => new AsyncRelayCommand(OnRegisterAsync);

        #endregion

        #region Constructor

        public RegisterPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private Task OnRegisterAsync()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
