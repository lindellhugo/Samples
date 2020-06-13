using System.Collections.ObjectModel;
using BookShelf.Web.Models;
using Papa.Common;
using MEFedMVVM.ViewModelLocator;
using System.ComponentModel.Composition;
using System.ComponentModel;
using System.Collections.Generic;
using Ria.Common;
using System.Linq;

namespace BookShelf
{
    [ExportViewModel("Checkout")]
    public class CheckoutViewModel : ViewModel
    {
        protected IPageConductor PageConductor { get; set; }
        protected IBookDataService BookDataService { get; set; }
     
        [ImportingConstructor]
        public CheckoutViewModel(
            IPageConductor pageConductor,
            IBookDataService bookDataService)
        {
            PageConductor = pageConductor;
            BookDataService = bookDataService;
            BookDataService.EntityContainer.PropertyChanged += BookDataService_PropertyChanged;

            InitializeModels();
            RegisterCommands();
            LoadData();
        }

        private void InitializeModels()
        {
            Checkouts = new ObservableCollection<Checkout>();
            SelectedCheckout = new Checkout();
        }

        private void BookDataService_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "HasChanges")
            {
                HasChanges = BookDataService.EntityContainer.HasChanges;
            }
        }

        protected override void RegisterCommands()
        {
            //SaveCheckoutCommand = new RelayCommand(OnSaveBook, () => HasChanges);
        }

        //private void OnSaveCheckout()
        //{
        //    BookDataService.Save(submitCallback, null);
        //}

        //private void submitCallback(SubmitOperation op)
        //{
        //    string msg = op.HasError ? "Save was unsuccessful" : "Save was successful";
        //    var dialogMessage = new SavedCheckoutDialogMessage(msg, "Save");
        //    Messenger.Default.Send(dialogMessage);
        //}

        public override void LoadData()
        {
            LoadCheckouts();
        }

        private void LoadCheckouts()
        {
            Checkouts.Clear();
            BookDataService.LoadCheckouts(LoadCheckoutsCallback, null);
        }

        private void LoadCheckoutsCallback(ServiceLoadResult<Checkout> result)
        {
            if (result.Error != null)
            {
                // handle error
            }
            else if (!result.Cancelled)
            {
                this.Checkouts = result.Entities as ICollection<Checkout>;
               
                    SelectedCheckout = Checkouts.FirstOrDefault();
               
            }
            
        }

        private bool _hasChanges;
        public bool HasChanges
        {
            get { return _hasChanges; }
            set
            {
                _hasChanges = value;
                RaisePropertyChanged("HasChanges");
            }
        }

        private ICollection<Checkout> _checkouts;
        public ICollection<Checkout> Checkouts
        {
            get { return _checkouts; }
            set
            {
                _checkouts = value;
                RaisePropertyChanged("Checkouts");
            }
        }

        private Checkout _selectedCheckout;
        public Checkout SelectedCheckout
        {
            get { return _selectedCheckout; }
            set
            {
                _selectedCheckout = value;
                RaisePropertyChanged("SelectedCheckout");
            }
        }
    }
}