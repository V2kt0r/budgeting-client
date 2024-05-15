using Budgeting.Contracts.Services;
using Budgeting.ViewModels.Base;
using System.Diagnostics;

namespace Budgeting.Services
{
    public class NavigationService : INavigationService
    {
        readonly IServiceProvider _services;

        protected static INavigation Navigation
        {
            get
            {
                INavigation navigation = Application.Current?.MainPage?.Navigation;
                if (navigation is not null)
                    return navigation;
                else
                {
                    //This is not good!
                    if (Debugger.IsAttached)
                        Debugger.Break();
                    throw new Exception();
                }
            }
        }

        public NavigationService(IServiceProvider services) => _services = services;

        public async Task NavigateBackAsync(bool force = false)
        {
            if (Navigation.NavigationStack.Count > 1)
            {
                if (!await CanContinueNavigationAsync(force))
                    return;

                await Navigation.PopAsync();
                await CallNavigatedTo(Navigation.NavigationStack.LastOrDefault());

                return;
            }

            throw new InvalidOperationException("No pages to navigate back to!");
        }

        public async Task NavigateHomeAsync(bool force = false)
        {
            if (Navigation.NavigationStack.Count > 1)
            {
                if (!await CanContinueNavigationAsync(force))
                    return;

                await Navigation.PopToRootAsync();

                var mainPage = _services.GetService<Views.MainPage>();
                await CallNavigatedTo(mainPage);

                return;
            }

            throw new InvalidOperationException("No pages to navigate back to!");
        }

        public async Task NavigateToPageAsync<T>(object parameter = null) where T : Page
        {
            var toPage = ResolvePage<T>();

            if (toPage is not null)
            {
                if (!await CanContinueNavigationAsync())
                    return;

                //Subscribe to the toPage's NavigatedTo event
                toPage.NavigatedTo += Page_NavigatedTo;

                //Get VM of the toPage
                var toViewModel = GetPageViewModelBase(toPage);

                //Call navigatingTo on VM, passing in the parameter
                if (toViewModel is not null)
                    await toViewModel.OnNavigatingTo(parameter);

                //Navigate to requested page
                await Navigation.PushAsync(toPage, true);

                //Subscribe to the toPage's NavigatedFrom event
                toPage.NavigatedFrom += Page_NavigatedFrom;
            }
            else
                throw new InvalidOperationException($"Unable to resolve type {typeof(T).FullName}");
        }

        public void SetAsHomePage(Page page)
        {
            Application.Current.MainPage = page;
        }

        private async Task<bool> CanContinueNavigationAsync(bool force = false)
        {
            if (force)
                return true;

            Page fromPage = Navigation.NavigationStack.LastOrDefault();
            var fromViewModel = GetPageViewModelBase(fromPage);

            bool continueNavigation = true;
            if (fromViewModel is not null)
                continueNavigation = await fromViewModel.OnNavigatingFrom(null);

            return continueNavigation;
        }

        private async void Page_NavigatedFrom(object sender, NavigatedFromEventArgs e)
        {
            //To determine forward navigation, we look at the 2nd to last item on the NavigationStack
            //If that entry equals the sender, it means we navigated forward from the sender to another page
            bool isForwardNavigation = Navigation.NavigationStack.Count > 1
                && Navigation.NavigationStack[^2] == sender;

            if (sender is Page thisPage)
            {
                if (!isForwardNavigation)
                {
                    thisPage.NavigatedTo -= Page_NavigatedTo;
                    thisPage.NavigatedFrom -= Page_NavigatedFrom;
                }

                await CallNavigatedFrom(thisPage, isForwardNavigation);
            }
        }

        private Task CallNavigatedFrom(Page p, bool isForward)
        {
            var fromViewModel = GetPageViewModelBase(p);

            if (fromViewModel is not null)
                return fromViewModel.OnNavigatedFrom(isForward);
            return Task.CompletedTask;
        }

        private async void Page_NavigatedTo(object sender, NavigatedToEventArgs e)
            => await CallNavigatedTo(sender as Page);

        private Task CallNavigatedTo(Page p)
        {
            var fromViewModel = GetPageViewModelBase(p);

            if (fromViewModel is not null)
                return fromViewModel.OnNavigatedTo();
            return Task.CompletedTask;
        }

        private ViewModelBase GetPageViewModelBase(Page p)
            => p?.BindingContext as ViewModelBase;

        private T ResolvePage<T>() where T : Page => _services.GetService<T>();
    }
}
