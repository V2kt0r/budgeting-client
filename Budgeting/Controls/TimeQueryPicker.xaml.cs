using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Budgeting.Controls
{
    public partial class TimeQueryWrapper : ObservableObject
    {
        [ObservableProperty]
        private DateTime? _time;

        [ObservableProperty]
        private string _title;

        public DateTime? LocalTime => Time?.ToLocalTime();
    }

    public partial class TimeQueryPicker : ContentView
    {
        #region Constants

        private static readonly ObservableCollection<TimeQueryWrapper> DefaultPossibilities = new()
        {
            new() {Time = DateTime.UtcNow - TimeSpan.FromDays(1), Title = "Last day"},
            new() {Time = DateTime.UtcNow - TimeSpan.FromDays(7), Title = "Last 7 days"},
            new() {Time = DateTime.UtcNow - TimeSpan.FromDays(30), Title = "Last month"},
            new() {Time = DateTime.UtcNow - TimeSpan.FromDays(365), Title = "Last year"},
            new() {Time = null, Title = "All time"}
        };

        #endregion

        #region Bindable Properties

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string), typeof(TimeQueryPicker), "Time");
        public static readonly BindableProperty PossibilitiesProperty =
            BindableProperty.Create(nameof(Possibilities), typeof(ObservableCollection<TimeQueryWrapper>), typeof(TimeQueryPicker), DefaultPossibilities);
        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(nameof(SelectedItem), typeof(TimeQueryWrapper), typeof(TimeQueryPicker), propertyChanged: (bindable, oldValue, newValue) =>
            {
                if (bindable is TimeQueryPicker picker && picker.SelectedItemChangedCommand != null && newValue is TimeQueryWrapper newTime)
                {
                    picker.SelectedItemChangedCommand.Execute(newTime.Time);
                }
            });
        public static readonly BindableProperty SelectedItemChangedCommandProperty =
            BindableProperty.Create(nameof(SelectedItemChangedCommand), typeof(IRelayCommand), typeof(TimeQueryPicker));

        #endregion

        #region Properties

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public ObservableCollection<TimeQueryWrapper> Possibilities
        {
            get => (ObservableCollection<TimeQueryWrapper>)GetValue(PossibilitiesProperty);
            set => SetValue(PossibilitiesProperty, value);
        }

        public TimeQueryWrapper SelectedItem
        {
            get => (TimeQueryWrapper)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public IRelayCommand SelectedItemChangedCommand
        {
            get => (IRelayCommand)GetValue(SelectedItemChangedCommandProperty);
            set => SetValue(SelectedItemChangedCommandProperty, value);
        }

        #endregion

        #region Constructor

        public TimeQueryPicker()
    	{
    		InitializeComponent();
    	}

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion
    }
}
