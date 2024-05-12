namespace Budgeting.Contracts.Services
{
    public interface INavigationService
    {
        Task NavigateBackAsync(bool force = false);
        Task NavigateHomeAsync(bool force = false);
        Task NavigateToPageAsync<T>(object parameter = null) where T : Page;
    }
}
