using Budgeting.Utils;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Org.OpenAPITools.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Budgeting.Controls
{
    public partial class TransactionItemCreateInternal : ObservableObject, INotifyPropertyChanged
    {
        #region Attributes

        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private string _description = string.Empty;

        [ObservableProperty]
        private decimal? _amount = null;

        [ObservableProperty]
        private PurchaseCategoryRead _purchaseCategory = null;

        [ObservableProperty]
        private ObservableCollection<string> _tagNames = new();

        #endregion

        #region Properties

        public static IEnumerable<PurchaseCategoryRead> PurchaseCategories { get; set; }

        #endregion

        #region Constructor

        public TransactionItemCreateInternal() { }

        public TransactionItemCreateInternal(TransactionItemCreate transactionItemCreate)
        {
            Name = transactionItemCreate.Name;
            Description = transactionItemCreate.Description;
            Amount = transactionItemCreate.Amount;
            PurchaseCategory = PurchaseCategories.First(i => i.Uuid == transactionItemCreate.PurchaseCategoryUuid);
            TagNames = transactionItemCreate.TagNames.ToObservableCollection();
        }

        #endregion

        #region Public Methods

        public static TransactionItemCreate ToTransactionItemCreate(TransactionItemCreateInternal transactionCreateInternal)
        {
            return new TransactionItemCreate
            (
                name: transactionCreateInternal.Name,
                description: transactionCreateInternal.Description,
                amount: transactionCreateInternal.Amount.Value,
                purchaseCategoryUuid: transactionCreateInternal.PurchaseCategory.Uuid,
                tagNames: transactionCreateInternal.TagNames.ToList()
            );
        }

        public TransactionItemCreate ToTransactionItemCreate()
        {
            return ToTransactionItemCreate(this);
        }

        public static bool IsValid(TransactionItemCreateInternal item)
        {
            return !string.IsNullOrEmpty(item.Name) && item.Amount is not null && item.PurchaseCategory is not null;
        }

        public bool IsValid()
        {
            return IsValid(this);
        }

        #endregion
    }

    public partial class EditableTransactionItemList : ContentView
    {
        #region Attributes

        private readonly Config.Config _config;

        private ObservableCollection<TransactionItemCreateInternal> _transactionItemCreateInternals = new()
        {
            new TransactionItemCreateInternal()
        };

        #endregion

        #region Bindable Properties

        public static readonly BindableProperty TransactionItemsProperty =
            BindableProperty.Create(nameof(TransactionItems), typeof(ObservableCollection<TransactionItemCreate>), typeof(EditableTransactionItemList), new ObservableCollection<TransactionItemCreate>());
        public static readonly BindableProperty PurchaseCategoriesProperty =
            BindableProperty.Create(nameof(PurchaseCategories), typeof(IEnumerable<PurchaseCategoryRead>), typeof(EditableTransactionItemList), default(IEnumerable<PurchaseCategoryRead>));
        public static readonly BindableProperty LastItemProperty =
            BindableProperty.Create(nameof(LastItem), typeof(TransactionItemCreateInternal), typeof(EditableTransactionItemList));

        #endregion

        #region Properties

        public ObservableCollection<TransactionItemCreate> TransactionItems
        {
            get => (ObservableCollection<TransactionItemCreate>)GetValue(TransactionItemsProperty);
            set => SetValue(TransactionItemsProperty, value);
        }

        public IEnumerable<Currency> CurrencyOptions => Enum.GetValues(typeof(Currency)).Cast<Currency>();
        public IEnumerable<PurchaseCategoryRead> PurchaseCategories
        {
            get => (IEnumerable<PurchaseCategoryRead>)GetValue(PurchaseCategoriesProperty);
            set => SetValue(PurchaseCategoriesProperty, value);
        }

        public ObservableCollection<TransactionItemCreateInternal> TransactionItemCreateInternals
        {
            get => _transactionItemCreateInternals;
            set
            {
                _transactionItemCreateInternals = value;
                OnPropertyChanged(nameof(TransactionItemCreateInternals));
            }
        }

        public TransactionItemCreateInternal LastItem
        {
            get => (TransactionItemCreateInternal)GetValue(LastItemProperty);
            set => SetValue(LastItemProperty, value);
        }

        public TransactionItemCreateInternal NewItem => TransactionItemCreateInternals.Last();

        public IRelayCommand AddCommand => new AsyncRelayCommand(OnAddAsync);
        public IRelayCommand<TransactionItemCreateInternal> RemoveCommand => new RelayCommand<TransactionItemCreateInternal>(OnRemove);

        #endregion

        #region Constructor

        public EditableTransactionItemList()
        {
            InitializeComponent();
            _config = IPlatformApplication.Current.Services.GetService<Config.Config>();
            TransactionItemCreateInternal.PurchaseCategories = PurchaseCategories;
            UpdateLastItem();
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private async Task OnAddAsync()
        {
            if (!NewItem.IsValid())
            {
                await Toaster.DisplayShortToastAsync("Please fill all necessary fields.");
                return;
            }
            ProcessNewItem();
            ResetValues();
        }

        private void OnRemove(TransactionItemCreateInternal item)
        {
            if (item == NewItem)
                return;

            var index = TransactionItemCreateInternals.IndexOf(item);
            TransactionItemCreateInternals.RemoveAt(index);
            TransactionItems.RemoveAt(index);
            UpdateLastItem();
        }

        private void ProcessNewItem()
        {
            TransactionItems.Add(NewItem.ToTransactionItemCreate());
            UpdateLastItem();
        }

        private void ResetValues()
        {
            TransactionItemCreateInternals.Add(new TransactionItemCreateInternal());
            UpdateLastItem();
        }

        private void UpdateLastItem()
        {
            LastItem = NewItem;
        }

        #endregion
    }
}
