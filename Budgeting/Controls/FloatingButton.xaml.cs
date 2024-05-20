using CommunityToolkit.Mvvm.Input;

namespace Budgeting.Controls;

public partial class FloatingButton : ContentView
{
    #region Bindable Properties

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(FloatingButton), "+");
    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(IRelayCommand), typeof(FloatingButton));
    public static readonly BindableProperty CommandParameterProperty =
        BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(FloatingButton), null);

    #endregion

    #region Properties

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public IRelayCommand Command
    {
        get => (IRelayCommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public object CommandParameter
    {
        get => (object)GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    #endregion

    #region Constructor

    public FloatingButton()
	{
		InitializeComponent();
	}

    #endregion
}