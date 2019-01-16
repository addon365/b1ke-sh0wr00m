using System;
using System.Diagnostics;
using Swc.Service.Inventory;
using Api.Domain.Inventory;
using Api.Database.Entity.Inventory.Purchase;

namespace ViewModel.Inventory
{
    public class PurchaseViewModel : ViewModelBase
    {
        private IPurchaseService _repository;
        
        private ScreenOpenMode Mode=ScreenOpenMode.New;
        public PurchaseViewModel()
        {
            GeneralInitilize();
            InitilizeForNew();
            TestData();
        }
        public PurchaseViewModel(string Identifier)
        {
            GeneralInitilize();
            
            Mode = ScreenOpenMode.Edit;
        }
        private void GeneralInitilize()
        {
            _repository = new addon.BikeShowRoomService.WebService.Inventory.PurchaseWebService();

            _MasterData = _repository.GetInitilize();

            WireCommands();
           

        }
        private void InitilizeForNew()
        {
           
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
                    AddPurchase();
                }
                else
                {
                    UpdatePurchase();
                }
            }
            catch (Exception ex)
            {
                if (msgbox != null)
                    msgbox.ShowUI(ex.Message);
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
        private PurchaseMasterData _MasterData;
        public PurchaseMasterData MasterData
        {
            get
            {
                return _MasterData;
            }
        }
        private Purchase _CurrentPurchase;
        public Purchase CurrentPurchase
        {
            get
            {
                return _CurrentPurchase;
            }

            set
            {
                if (_CurrentPurchase != value)
                {
                    _CurrentPurchase = value;
                    OnPropertyChanged("CurrentPurchase");
                  
                    FindCommand.IsEnabled = true;
                    SaveCommand.IsEnabled = true;
                }
            }
        }
        private async void AddPurchase()
        {
            if (!InsertValidation())
                return;

            SaveCommand.IsEnabled = false;

           


            ClearData();

        }
        private async void UpdatePurchase()
        {
            


            await  _repository.Update(CurrentPurchase);
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
