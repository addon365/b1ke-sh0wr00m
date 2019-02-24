using addon365.Database.Entity.Inventory.Purchases;
using addon365.Domain.Entity.Paging;
using addon365.Database.Service.Inventory;
using System;

namespace addon365.UI.ViewModel.Inventory
{


    public class PurchaseListViewModel : ViewModelBase
    {
        private readonly IPurchaseService _repository;
        private Threenine.Data.Paging.IPaginate<Purchase> _Data;
        private Purchase _Selected;
        private PagingParams pagingParams;
        public PurchaseListViewModel(IPurchaseService purchaseService)
        {
            _repository = purchaseService;
            PagingViewModel = new PagingViewModel<Purchase>(new Func<addon365.Domain.Entity.Paging.PagingParams, Threenine.Data.Paging.IPaginate<Purchase>>(RefreshData));
            WireCommands();
           
        }
        #region Commands
        private void WireCommands()
        {
            PrintCommand = new RelayCommand(PrintEnquiry);
            
            EditCommand = new RelayCommand(EditMethod);
        }
        public RelayCommand PrintCommand
        {
            get;
            private set;
        }
       
        public RelayCommand EditCommand
        {
            get;
            private set;
        }
        #endregion

        private Threenine.Data.Paging.IPaginate<Purchase> RefreshData(PagingParams pagingParams)
        {

            return _repository.GetAll(pagingParams);

        }
        public PagingViewModel<Purchase> PagingViewModel { get; private set; }
        public Threenine.Data.Paging.IPaginate<Purchase> Data
        {
            get
            {
        
                return _Data;
            }

            set
            {
                if (_Data != value)
                {
                    _Data = value;
                    OnPropertyChanged("Enquiries");

                }
            }
        }
        public Purchase Selected
        { get
            {
                return _Selected;
            }
            set
            {
                if(_Selected!=value)
                {
                    _Selected = value;
                    OnPropertyChanged("Selected");
                    PrintCommand.IsEnabled = true;
                    EditCommand.IsEnabled = true;
                }

            }
        }
        public Edit<Purchase> Edit { get; set; }
        public ICrystalReport ReportObj { get; set; }

        public void PrintEnquiry()
        {
            try { 
            if (ReportObj == null)
                return;


            
            }
            catch(Exception ex)
            {
                MessageBox.ShowUI(ex.StackTrace);
            }
        }
        
        public void EditMethod()
        {
            try
            {
                if (Edit == null)
                    return;

                Edit(Selected);
            }
            catch(Exception ex)
            {
                MessageBox.ShowUI(ex.Message);
            }

        }

      
    }
}
