using Org.OpenAPITools.Model;

namespace Budgeting.Controls;

public partial class EditableTransactionItem : ContentView
{
    #region Bindable Properties

    public static readonly BindableProperty NameProperty =
        BindableProperty.Create(nameof(Name), typeof(string), typeof(EditableTransactionItem), string.Empty);
    public static readonly BindableProperty DescriptionProperty =
        BindableProperty.Create(nameof(Description), typeof(string), typeof(EditableTransactionItem), string.Empty);
    public static readonly BindableProperty AmountProperty =
        BindableProperty.Create(nameof(Amount), typeof(int?), typeof(EditableTransactionItem), null);
    public static readonly BindableProperty TagNamesProperty =
        BindableProperty.Create(nameof(TagNames), typeof(IEnumerable<string>), typeof(EditableTransactionItem), default(IEnumerable<string>));
    public static readonly BindableProperty PurchaseCategoryProperty =
        BindableProperty.Create(nameof(PurchaseCategory), typeof(PurchaseCategoryRead), typeof(EditableTransactionItem));
    public static readonly BindableProperty PurchaseCategoriesProperty =
        BindableProperty.Create(nameof(PurchaseCategories), typeof(IEnumerable<PurchaseCategoryRead>), typeof(EditableTransactionItem), default(IEnumerable<PurchaseCategoryRead>));

    #endregion

    #region Properties

    public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }

    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    public int? Amount
    {
        get => (int?)GetValue(AmountProperty);
        set => SetValue(AmountProperty, value);
    }

    public IEnumerable<string> TagNames
    {
        get => (IEnumerable<string>)GetValue(TagNamesProperty);
        set => SetValue(TagNamesProperty, value);
    }

    public PurchaseCategoryRead PurchaseCategory
    {
        get => (PurchaseCategoryRead)GetValue(PurchaseCategoryProperty);
        set => SetValue(PurchaseCategoryProperty, value);
    }

    public IEnumerable<PurchaseCategoryRead> PurchaseCategories
    {
        get => (IEnumerable<PurchaseCategoryRead>)GetValue(PurchaseCategoriesProperty);
        set => SetValue(PurchaseCategoriesProperty, value);
    }

    #endregion

    #region Constructor

    public EditableTransactionItem()
	{
		InitializeComponent();
	}

    #endregion
}