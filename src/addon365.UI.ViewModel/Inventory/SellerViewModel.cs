using System;
using System.Diagnostics;
using addon365.Database.Service.Inventory;
using addon365.Database.Entity.Inventory;
using addon365.IService.Inventory;

namespace addon365.UI.ViewModel.Inventory
{
    public class SellerViewModel : ViewModelBase
    {
        private ISellerService _repository;
        
        private ScreenOpenMode Mode=ScreenOpenMode.New;
        public SellerViewModel()
        {
            GeneralInitilize();
            InitilizeForNew();
            TestData();
        }
        public SellerViewModel(string Id)
        {
            GeneralInitilize();
            CurrentSeller=_repository.Get(Id);
            Mode = ScreenOpenMode.Edit;
        }
        private void GeneralInitilize()
        {
            _repository = new addon365.WebClient.Service.WebService.Inventory.SellerWebService();

           

            WireCommands();
           

        }
        private void InitilizeForNew()
        {
            Mode = ScreenOpenMode.New;
            CurrentSeller=new Seller();
            _CurrentSeller.BusinessContact = new addon365.Database.Entity.Crm.BusinessContact();
            _CurrentSeller.BusinessContact.ContactAddress = new addon365.Database.Entity.Crm.AddressMaster();
        }
        [Conditional("DEBUG")]
        private void TestData()
        {

            
        }
        #region Commands
        private void WireCommands()
        {
          
            SaveCommand = new RelayCommand(Save);
            FindCommand = new RelayCommand(Find);
           
        }
        public RelayCommand SaveCommand
        {
            get;
            private set;
        }
        public async void Save()
        {
            try
            {
                if (Mode == ScreenOpenMode.New)
                {
                    Add();
                }
                else
                {
                    UpdatePurchase();
                }
            }
            catch (Exception ex)
            {
                if (MessageBox != null)
                    MessageBox.ShowUI(ex.Message);
            }
        }
        public RelayCommand FindCommand
        {
            get;
            private set;
        }
        public void Find()
        {
        }
     
        #endregion
      
      
        private Seller _CurrentSeller;
        public Seller CurrentSeller
        {
            get
            {
                return _CurrentSeller;
            }

            set
            {
                if (_CurrentSeller != value)
                {
                    _CurrentSeller = value;
                 
                    OnPropertyChanged("CurrentSeller");
                    SaveCommand.IsEnabled = true;
                }
            }
        }
        private async void Add()
        {
            if (!InsertValidation())
                return;

           
            SaveCommand.IsEnabled = false;
            await _repository.Insert(CurrentSeller);
            


            ClearData();

        }
        private async void UpdatePurchase()
        {
            


            await  _repository.Update(CurrentSeller);
        }
        private bool InsertValidation()
        {
            

            return true;
        }
        private void ClearData()
        {
            InitilizeForNew();
           
        }  
       
    }
   

}
