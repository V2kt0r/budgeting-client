using Budgeting.Utils;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Budgeting.Controls
{
    public partial class EditableTagNamesList : ContentView
    {
        #region Bindbable Properties

        public static readonly BindableProperty TagNamesProperty =
            BindableProperty.Create(nameof(TagNames), typeof(ObservableCollection<string>), typeof(EditableTagNamesList));

        #endregion

        #region Properties

        public ObservableCollection<string> TagNames
        {
            get => (ObservableCollection<string>)GetValue(TagNamesProperty);
            set => SetValue(TagNamesProperty, value);
        }

        public IRelayCommand AddCommand => new AsyncRelayCommand(OnAddAsync);
        public IRelayCommand<string> EditCommand => new AsyncRelayCommand<string>(OnEditAsync);

        #endregion

        #region Constructor

        public EditableTagNamesList()
    	{
    		InitializeComponent();
    	}

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private async Task OnAddAsync()
        {
            string newTagName = await Application.Current.MainPage.DisplayPromptAsync(title: "Create a new tag", message: "Please enter a name for the new tag", placeholder: "Fast food, Hobby");
            
            if (newTagName ==  null || string.IsNullOrEmpty(newTagName))
            {
                return;
            }

            // Check if tag already exists
            if (TagNames.Contains(newTagName))
            {
                await Toaster.DisplayLongToastAsync("Tag already exists. Please choose an other name.");
            }
            else
            {
                TagNames.Add(newTagName);
                await Toaster.DisplayShortToastAsync($"Tag '{newTagName}' added successfully!");
            }
        }

        private async Task OnEditAsync(string oldTagName)
        {
            string newTagName = await Application.Current.MainPage.DisplayPromptAsync(title: "Create a new tag", message: "Please enter a name for the new tag", placeholder: "Fast food, Hobby", initialValue: oldTagName);

            if (newTagName == null || string.IsNullOrEmpty(newTagName) || oldTagName == newTagName)
            {
                return;
            }

            if (TagNames.Contains(newTagName))
            {
                await Toaster.DisplayLongToastAsync("Tag already exists. Please choose an other name.");
            }
            else
            {
                TagNames[TagNames.IndexOf(oldTagName)] = newTagName;
                await Toaster.DisplayShortToastAsync($"Tag '{oldTagName}' renamed to '{newTagName}'.");
            }
        }

        #endregion
    }
}