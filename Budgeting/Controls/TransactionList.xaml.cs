using CommunityToolkit.Mvvm.Input;
using Org.OpenAPITools.Model;

namespace Budgeting.Controls;

public partial class TransactionList : ContentView
{
    #region Bindable Properties

	public static readonly BindableProperty TransactionsProperty = 
		BindableProperty.Create(nameof(Transactions), typeof(IEnumerable<TransactionRead>), typeof(TransactionList), default(IEnumerable<TransactionRead>));
	public static readonly BindableProperty TransactionSelectedCommandProperty = 
		BindableProperty.Create(nameof(TransactionSelectedCommand), typeof(IRelayCommand<TransactionRead>), typeof(TransactionList));
	public static readonly BindableProperty FinishedLoadingProperty = 
		BindableProperty.Create(nameof(FinishedLoading), typeof(bool), typeof(TransactionList), false);

    #endregion

    #region Properties

    public IEnumerable<TransactionRead> Transactions
	{
        get => (IEnumerable<TransactionRead>)GetValue(TransactionsProperty);
        set => SetValue(TransactionsProperty, value);
    }

	public IRelayCommand<TransactionRead> TransactionSelectedCommand
	{
		get => (IRelayCommand<TransactionRead>)GetValue(TransactionSelectedCommandProperty);
        set => SetValue(TransactionSelectedCommandProperty, value);
    }

	public bool FinishedLoading
	{
		get => (bool)GetValue(FinishedLoadingProperty);
        set => SetValue(FinishedLoadingProperty, value);
    }

    #endregion

    #region Constructor

    public TransactionList()
	{
		InitializeComponent();
	}

	#endregion

	#region Public Methods

	#endregion

	#region Private Methods

	#endregion
}