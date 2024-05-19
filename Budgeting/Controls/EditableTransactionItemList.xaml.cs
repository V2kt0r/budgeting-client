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

        #endregion
    }

    public partial class EditableTransactionItemList : ContentView
    {
        #region Attributes

        private readonly Config.Config _config;

        private ObservableCollection<TransactionItemCreateInternal> _transactionItemCreateInternals = new();

        private TransactionItemCreateInternal _transactionItemCreateInternal = new();

        private string _name = string.Empty;
        private string _description = string.Empty;
        private decimal? _amount = null;
        private PurchaseCategoryRead _purchaseCategory = null;
        private ObservableCollection<string> _tagNames = new()
        {
            "Tag1", "TagName2", "TagLongerName", "Tag3", "Tag4", "Tag5"
        };

        #endregion

        #region Bindable Properties

        public static readonly BindableProperty TransactionItemsProperty =
            BindableProperty.Create(nameof(TransactionItems), typeof(ObservableCollection<TransactionItemCreate>), typeof(EditableTransactionItemList), new ObservableCollection<TransactionItemCreate>());
        public static readonly BindableProperty PurchaseCategoriesProperty =
            BindableProperty.Create(nameof(PurchaseCategories), typeof(IEnumerable<PurchaseCategoryRead>), typeof(EditableTransactionItemList), default(IEnumerable<PurchaseCategoryRead>));

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

        public TransactionItemCreateInternal TransactionItemCreateInternal
        {
            get => _transactionItemCreateInternal;
            set
            {
                _transactionItemCreateInternal = value;
                OnPropertyChanged(nameof(TransactionItemCreateInternal));
            }
        }


        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public decimal? Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }

        public PurchaseCategoryRead PurchaseCategory
        {
            get => _purchaseCategory;
            set
            {
                _purchaseCategory = value;
                OnPropertyChanged(nameof(PurchaseCategory));
            }
        }

        public ObservableCollection<string> TagNames
        {
            get => _tagNames;
            set
            {
                _tagNames = value;
                OnPropertyChanged(nameof(TagNames));
            }
        }

        public IRelayCommand AddCommand => new AsyncRelayCommand(OnAddAsync);
        public IRelayCommand<TransactionItemCreateInternal> RemoveCommand => new RelayCommand<TransactionItemCreateInternal>(OnRemove);

        #endregion

        #region Constructor

        public EditableTransactionItemList()
        {
            InitializeComponent();
            _config = IPlatformApplication.Current.Services.GetService<Config.Config>();
            TransactionItemCreateInternal.PurchaseCategories = PurchaseCategories;
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private async Task OnAddAsync()
        {
            if (!NewTransactionItemIsValid())
            {
                await Toaster.DisplayShortToastAsync("Please fill all necessary fields.");
                return;
            }
            ProcessNewItem();
            ResetValues();
        }

        private void OnRemove(TransactionItemCreateInternal item)
        {
            var index = TransactionItemCreateInternals.IndexOf(item);
            TransactionItemCreateInternals.RemoveAt(index);
            TransactionItems.RemoveAt(index);
        }

        private bool NewTransactionItemIsValid()
        {
            if (string.IsNullOrEmpty(TransactionItemCreateInternal.Name) || TransactionItemCreateInternal.Amount is null || TransactionItemCreateInternal.PurchaseCategory is null)
                return false;
            else
                return true;
        }

        private void ProcessNewItem()
        {
            TransactionItemCreateInternals.Add(TransactionItemCreateInternal);
            TransactionItems.Add(TransactionItemCreateInternal.ToTransactionItemCreate());
        }

        private void ResetValues()
        {
            TransactionItemCreateInternal = new();
        }

        #endregion
    }
}
