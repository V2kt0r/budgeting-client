using CommunityToolkit.Mvvm.Input;
using Org.OpenAPITools.Model;

namespace Budgeting.Controls;

public partial class TransactionItemList : ContentView
{
    #region Bindable Properties

    public static readonly BindableProperty TransactionProperty =
        BindableProperty.Create(nameof(Transaction), typeof(TransactionRead), typeof(TransactionItemList));
    public static readonly BindableProperty TransactionItemsProperty = 
        BindableProperty.Create(nameof(TransactionItems), typeof(IEnumerable<TransactionItemRead>), typeof(TransactionItemList), default(IEnumerable<TransactionItemRead>));
    public static readonly BindableProperty TransactionItemSelectedCommandProperty = 
        BindableProperty.Create(nameof(TransactionItemSelectedCommand), typeof(IRelayCommand), typeof(TransactionItemList));
    public static readonly BindableProperty FinishedLoadingProperty =
        BindableProperty.Create(nameof(FinishedLoading), typeof(bool), typeof(TransactionItemList), false);

    #endregion

    #region Properties

    public TransactionRead Transaction
    {
        get => (TransactionRead)GetValue(TransactionProperty);
        set => SetValue(TransactionProperty, value);
    }

    public IEnumerable<TransactionItemRead> TransactionItems
    {
        get => (IEnumerable<TransactionItemRead>)GetValue(TransactionItemsProperty);
        set => SetValue(TransactionItemsProperty, value);
    }

    public IRelayCommand TransactionItemSelectedCommand
    {
        get => (IRelayCommand)GetValue(TransactionItemSelectedCommandProperty);
        set => SetValue(TransactionItemSelectedCommandProperty, value);
    }

    public bool FinishedLoading
    {
        get => (bool)GetValue(FinishedLoadingProperty);
        set => SetValue(FinishedLoadingProperty, value);
    }

    #endregion

    #region Constructor

    public TransactionItemList()
	{
		InitializeComponent();
	}

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}