using Budgeting.ViewModels;

namespace Budgeting.Views;

public partial class TransactionDetailPage : ContentPage
{
	private readonly TransactionDetailPageViewModel _viewModel;

	public TransactionDetailPage(TransactionDetailPageViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
	}
}