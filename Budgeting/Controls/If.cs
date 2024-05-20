namespace Budgeting.Controls;

public class If : ContentView
{
	public static readonly BindableProperty ConditionProperty = 
		BindableProperty.Create(nameof(Condition), typeof(bool), typeof(If), false, propertyChanged: OnConditionChanged);
    public static readonly BindableProperty TrueProperty =
        BindableProperty.Create(nameof(True), typeof(View), typeof(If), null, propertyChanged: OnConditionChanged);
    public static readonly BindableProperty FalseProperty =
        BindableProperty.Create(nameof(False), typeof(View), typeof(If), null, propertyChanged: OnConditionChanged);

	public bool Condition
	{
        get => (bool)GetValue(ConditionProperty);
        set => SetValue(ConditionProperty, value);
    }

    public View True
    {
        get => (View)GetValue(TrueProperty);
        set => SetValue(TrueProperty, value);
    }

    public View False
    {
        get => (View)GetValue(FalseProperty);
        set => SetValue(FalseProperty, value);
    }

	private static void OnConditionChanged(BindableObject bindable, object oldValue, object newValue)
	{
        if (bindable is If ifControl)
		{
            ifControl.UpdateContent();
        }
    }

    private void UpdateContent()
    {
        Content = Condition ? True : False;
    }
}