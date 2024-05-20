using Budgeting.ViewModels;

namespace Budgeting.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _viewModel;

        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.OnAppearingAsync();
        }

        private async void CurrencyPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            await _viewModel.OnCurrencyChangedAsync();
        }
    }

}
