
using addon365.Database.Entity;
using addon365.Database.Entity.Enquiries;
using addon365.Domain.Entity.Enquiries;
using addon365.Database.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using addon365.Database.Entity.Crm;
using addon365.Database.Entity.Inventory.Catalog;
using addon365.IService;
using Microsoft.Extensions.DependencyInjection;

namespace addon365.UI.ViewModel
{
    public class EnquiryViewModel : ViewModelBase
    {
        private IEnquiriesService _repository;
        private Enquiry _currentEnquiry;
        private Contact _currentContact;
        private MarketingZone _currentMarketingZone;
        private EnquiryCatalogItem _enquiryItem,_SelectedDataGridProduct, _FinanceEnquiryProduct;
        private EnquiryFinanceQuotation _financeQuotation, _SelectedDataGridFinanceQuotation;
        private EnquiryExchangeQuotation _exchangeQuotation;
        private ScreenOpenMode Mode=ScreenOpenMode.New;
        public EnquiryViewModel()
        {
            GeneralInitilize();
            InitInsert();
            InitDefaultValues();
        }
        public EnquiryViewModel(string Identifier)
        {
            GeneralInitilize();
            Enquiry eq=_repository.GetEnquiries(Identifier);
            CurrentEnquiry = eq;
            CurrentContact = eq.Contact;
            EnquiryItems = new ObservableCollection<EnquiryCatalogItem>(eq.EnquiryItems);
            CurrentFinanceQuotation = new EnquiryFinanceQuotation();
            CurrentExchangeQuotation = new EnquiryExchangeQuotation();
            CurrentFinanceEnquiryProduct =EnquiryItems.FirstOrDefault();
            ExchangeQuotations = new ObservableCollection<EnquiryExchangeQuotation>(eq.EnquiryExchangeQuotations);
            CurrentExchangeQuotation = ExchangeQuotations.FirstOrDefault();
            Mode = ScreenOpenMode.Edit;
        }
        private void GeneralInitilize()
        {
            var Scope = Startup.Instance.provider.CreateScope();

            _repository = Scope.ServiceProvider.GetRequiredService<IEnquiriesService>();

            EnquiryMasterData = _repository.GetInitilizeEnquiries();

            WireCommands();
            SaveEnquiryCommand.IsEnabled = true;

        }
        [Conditional("DEBUG")]
        private void InitDefaultValues()
        {

            CurrentEnquiry = new Enquiry();
            CurrentEnquiry.EnquiryDate = System.DateTime.Now;


            CurrentContact = new Contact
            {
                FirstName = "User",
                Address = "14,street, Choolaimedu ",
                MobileNumber = "9645645666",
                Identifier = "Identifier1",
                Place = "Choolaimedu"
            };
            CurrentEnquiryItem.Item = EnquiryMasterData.CatalogItems.FirstOrDefault();

            CurrentFinanceQuotation = new EnquiryFinanceQuotation
            {
               
                InitialDownPayment = 222,
                MonthlyEMIAmount = 3333,
                NumberOfMonths = 12,
            };
            CurrentExchangeQuotation = new EnquiryExchangeQuotation
            {
                ExpectedAmount = 22333.66,
                Model = "Indigo",
                NoOfOwner = 1,
                Year = 2000,
                QuotatedAmount = 55676,
                

            };
            CurrentMarketingZone = EnquiryMasterData.MarketingZones.FirstOrDefault();

            AddEnquiryItem();
            CurrentFinanceEnquiryProduct = EnquiryItems.FirstOrDefault();

        }
        #region Commands
        private void WireCommands()
        {
            UpdateEnquiryCommand = new RelayCommand(UpdateEnquiry);
            SaveEnquiryCommand = new RelayCommand(SaveEnquiry);
            FindEnquiryCommand = new RelayCommand(FindEnquiry);
            AddEnquiryItemCommand = new RelayCommand(AddEnquiryItem);
            AddFinanceQuotationCommand = new RelayCommand(AddFinanceQuotation);
            DeleteRowEnquiryProductCommand = new RelayCommand(RemoveEnquiryProduct);
            DeleteRowFinanceQuotationCommand = new RelayCommand(RemoveFinanceQuotationRow);

        }
        public RelayCommand DeleteRowEnquiryProductCommand
        {
            get;
            private set;
        }
        public RelayCommand DeleteRowFinanceQuotationCommand
        {
            get;
            private set;
        }
        public RelayCommand UpdateEnquiryCommand
        {
            get;
            private set;
        }
        public RelayCommand SaveEnquiryCommand
        {
            get;
            private set;
        }
        public RelayCommand FindEnquiryCommand
        {
            get;
            private set;
        }
        public RelayCommand AddEnquiryItemCommand
        {
            get;
            private set;
        }
        public RelayCommand AddFinanceQuotationCommand
        {
            get;
            private set;
        }

        #endregion
        public InitilizeEnquiry EnquiryMasterData { get; set; }
        public MarketingZone CurrentMarketingZone
        {
            get
            {
                return _currentMarketingZone;
            }

            set
            {
                if (_currentMarketingZone != value)
                {
                    _currentMarketingZone = value;
                    OnPropertyChanged("MarketingZone");

                }
            }
        }

        private ObservableCollection<EnquiryCatalogItem> _enquiryItems;
        public ObservableCollection<EnquiryCatalogItem> EnquiryItems
        {
            get
            {
                return _enquiryItems;
            }
            set
            {
                _enquiryItems = value;
                OnPropertyChanged("EnquiryItems");
            }
        }


        //private ObservableCollection<EnquiryFinanceQuotation> _enquiryFinanceQuotations;
        //public ObservableCollection<EnquiryFinanceQuotation> FinanceQuotations
        //{
        //    get
        //    {
        //        return _enquiryFinanceQuotations;
        //    }
        //    set
        //    {
        //        _enquiryFinanceQuotations = value;
        //        OnPropertyChanged("FinanceQuotations");
        //    }
        //}

        private ObservableCollection<EnquiryExchangeQuotation> _enquiryExchangeQuotations;
        public ObservableCollection<EnquiryExchangeQuotation> ExchangeQuotations
        {
            get
            {
                return _enquiryExchangeQuotations;
            }
            set
            {
                _enquiryExchangeQuotations = value;
                OnPropertyChanged("ExchangeQuotations");
            }
        }


        public IEnumerable<EnquiryAccessories> enquiryAccessories { get; set; }

        public Enquiry CurrentEnquiry
        {
            get
            {
                return _currentEnquiry;
            }

            set
            {
                if (_currentEnquiry != value)
                {
                    _currentEnquiry = value;
                    OnPropertyChanged("CurrentEnquiry");
                  
                    FindEnquiryCommand.IsEnabled = true;
                    UpdateEnquiryCommand.IsEnabled = true;
                }
            }
        }
        public Contact CurrentContact
        {
            get
            {
                return _currentContact;
            }

            set
            {
                if (_currentContact != value)
                {
                    _currentContact = value;
                    OnPropertyChanged("CurrentContact");
                    
                }
            }
        }
        public EnquiryCatalogItem CurrentEnquiryItem
        {
            get
            {
                return _enquiryItem;
            }

            set
            {
                if (_enquiryItem != value)
                {
                    _enquiryItem = value;
                    OnPropertyChanged("CurrentEnquiryItem");

                    AddEnquiryItemCommand.IsEnabled = true;
                }
            }
        }
        public EnquiryCatalogItem SelectedDataGridProduct
        {
            get
            {
                return _SelectedDataGridProduct;
            }

            set
            {
                if (_SelectedDataGridProduct != value)
                {
                    _SelectedDataGridProduct = value;
                    OnPropertyChanged("SelectedDataGridProduct");
                    DeleteRowEnquiryProductCommand.IsEnabled = true;

                }
            }
        }
        public EnquiryFinanceQuotation SelectedDataGridFinanceQuotation
        {
            get
            {
                return _SelectedDataGridFinanceQuotation;
            }

            set
            {
                if (_SelectedDataGridFinanceQuotation != value)
                {
                    _SelectedDataGridFinanceQuotation = value;
                    OnPropertyChanged("SelectedDataGridFinanceQuotation");
                    DeleteRowFinanceQuotationCommand.IsEnabled = true;

                }
            }
        }
        public EnquiryCatalogItem CurrentFinanceEnquiryProduct
        {
            get
            {
                return _FinanceEnquiryProduct;
            }

            set
            {
                if (_FinanceEnquiryProduct != value)
                {
                    _FinanceEnquiryProduct = value;
                    OnPropertyChanged("CurrentFinanceEnquiryProduct");

                    AddFinanceQuotationCommand.IsEnabled = true;
                }
            }
        }
        public EnquiryFinanceQuotation CurrentFinanceQuotation
        {
            get
            {
                return _financeQuotation;
            }

            set
            {
                if (_financeQuotation != value)
                {
                    _financeQuotation = value;
                    OnPropertyChanged("CurrentFinanceQuotation");

                    AddFinanceQuotationCommand.IsEnabled = true;
                }
            }
        }
        public EnquiryExchangeQuotation CurrentExchangeQuotation
        {
            get
            {
                return _exchangeQuotation;
            }

            set
            {
                if (_exchangeQuotation != value)
                {
                    _exchangeQuotation = value;
                    OnPropertyChanged("CurrentExchangeQuotation");


                }
            }
        }
        public IMsgBox msg { get; set; }
        public async void SaveEnquiry()
        {
            try
            { 
          if(Mode==ScreenOpenMode.New)
            {
                AddEnquiry();
            }
          else
            {
                UpdateEnquiry();
            }
            }
            catch(Exception ex)
            {
                if (msg != null)
                    msg.ShowUI(ex.Message);
            }
        }
        private async void AddEnquiry()
        {
            if (!InsertValidation())
                return;

            SaveEnquiryCommand.IsEnabled = false;

            if (CurrentExchangeQuotation.Model != "")
            {
                AddExchangeQuotation();
            }

            InsertEnquiryModel insertEnquiryModel = new InsertEnquiryModel();
            CurrentEnquiry.Contact = CurrentContact;
            insertEnquiryModel.Enquiry = CurrentEnquiry;
            insertEnquiryModel.EnquiryItems = EnquiryItems;
            insertEnquiryModel.enquiryExchangeQuotations = ExchangeQuotations;

            await _repository.Insert(insertEnquiryModel);


            ClearData();

        }

        private async void UpdateEnquiry()
        {
            


            await  _repository.Update(CurrentEnquiry);
        }
        bool InsertValidation()
        {
            if (_currentEnquiry == null)
                return false;

            if (_enquiryItem == null)
                return false;

            return true;
        }
        void InitInsert()
        {
            CurrentEnquiry = new Enquiry() { EnquiryDate = CurrentEnquiry==null?System.DateTime.Now:CurrentEnquiry.EnquiryDate };
            CurrentContact = new Contact();
            CurrentEnquiryItem = new EnquiryCatalogItem();
            CurrentEnquiryItem.Item = new CatalogItem();
            CurrentFinanceQuotation = new EnquiryFinanceQuotation();
            CurrentExchangeQuotation = new EnquiryExchangeQuotation();

            EnquiryItems=new ObservableCollection<EnquiryCatalogItem>();
            
            ExchangeQuotations = new ObservableCollection<EnquiryExchangeQuotation>();
            
        }
        void ClearData()
        {
            InitInsert();
            EnquiryItems.Clear();
            ExchangeQuotations.Clear();
        }
        public void FindEnquiry()
        {
        }
       
        public void AddEnquiryItem()
        {
            if (!InsertValidation())
                return;

            EnquiryCatalogItem enquiryItem = new EnquiryCatalogItem();
            enquiryItem.Item = _enquiryItem.Item;
            enquiryItem.CatalogItemId = _enquiryItem.Item.Id;

            enquiryItem.OnRoadPrice = _enquiryItem.Item.Price;
            enquiryItem.AccessoriesAmount = _enquiryItem.AccessoriesAmount;
            enquiryItem.OtherAmount = _enquiryItem.OtherAmount;
            enquiryItem.TotalAmount = enquiryItem.OnRoadPrice + enquiryItem.AccessoriesAmount+enquiryItem.OtherAmount;

            EnquiryItems.Add(enquiryItem);
            CurrentEnquiryItem = new EnquiryCatalogItem();
        }
        public void AddFinanceQuotation()
        {

            CurrentFinanceQuotation.EnquiryProductId=CurrentFinanceEnquiryProduct.Id;
            if (CurrentFinanceEnquiryProduct.EnquiryFinanceQuotations == null)
            { 
                CurrentFinanceEnquiryProduct.EnquiryFinanceQuotations = new ObservableCollection<EnquiryFinanceQuotation>();
                OnPropertyChanged("CurrentFinanceEnquiryProduct");
            }

            CurrentFinanceEnquiryProduct.EnquiryFinanceQuotations.Add(CurrentFinanceQuotation);
            
            CurrentFinanceQuotation = new EnquiryFinanceQuotation();
            
        }
        public void AddExchangeQuotation()
        {

            ExchangeQuotations.Clear();
            ExchangeQuotations.Add(CurrentExchangeQuotation);
        }
        public void RemoveEnquiryProduct()
        {
            EnquiryItems.Remove(SelectedDataGridProduct);
        }
        public void RemoveFinanceQuotationRow()
        {
            CurrentFinanceEnquiryProduct.EnquiryFinanceQuotations.Remove(SelectedDataGridFinanceQuotation);
        }
    }
   

}
