namespace Budgeting.Controls;

public partial class TagPills : ContentView
{
    #region Bindable Property

    public static readonly BindableProperty TagsProperty = 
		BindableProperty.Create(nameof(Tags), typeof(IEnumerable<string>), typeof(TagPills), default(IEnumerable<string>));

    #endregion

    #region Properties

    public IEnumerable<string> Tags
	{
        get => (IEnumerable<string>)GetValue(TagsProperty);
        set => SetValue(TagsProperty, value);
    }

    #endregion

    #region Constructor

	public TagPills()
	{
		InitializeComponent();
	}

    #endregion
}