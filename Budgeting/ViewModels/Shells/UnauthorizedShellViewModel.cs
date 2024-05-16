using Budgeting.Contracts.Services;
using Budgeting.ViewModels.Base;
using Budgeting.Views;
using CommunityToolkit.Mvvm.Input;

namespace Budgeting.ViewModels.Shells
{
    public class UnauthorizedAppShellViewModel : ViewModelBase
    {
        #region Attributes

        private readonly IAuthService _authService;

        #endregion

        #region Properties

        public IAuthService AuthService => _authService;

        #endregion

        #region Constructor

        public UnauthorizedAppShellViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion
    }
}
