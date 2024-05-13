using Budgeting.Contracts.Services;
using Budgeting.ViewModels.Base;

namespace Budgeting.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
