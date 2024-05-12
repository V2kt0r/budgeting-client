using CommunityToolkit.Mvvm.ComponentModel;

namespace Budgeting.ViewModels.Base
{
    public abstract class ViewModelBase : ObservableObject
    {
        public virtual Task<bool> OnNavigatingFrom(object parameter)
            => Task.FromResult(true);

        public virtual Task OnNavigatingTo(object parameter)
            => Task.CompletedTask;

        public virtual Task OnNavigatedFrom(bool isForwardNavigation)
            => Task.CompletedTask;

        public virtual Task OnNavigatedTo()
            => Task.CompletedTask;
    }
}
