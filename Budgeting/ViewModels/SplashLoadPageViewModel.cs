using Budgeting.Contracts.Services;
using Budgeting.ViewModels.Base;
using Budgeting.Views;

namespace Budgeting.ViewModels
{
    public class SplashLoadPageViewModel : ViewModelBase
    {
        #region Attributes

        private readonly INavigationService _navigationService;

        #endregion

        #region Constructor

        public SplashLoadPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Task.Run(async () => await InitializeAsync()).Wait();
        }

        #endregion

        #region Public Methods

        public async Task OnAppearingAsync()
        {
            await _navigationService.NavigateToPageAsync<LoginPage>();
        }

        #endregion

        #region Private Methods

        private async Task InitializeAsync()
        {
            
        }

        #endregion
    }
}
