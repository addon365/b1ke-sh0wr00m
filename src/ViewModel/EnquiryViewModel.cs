
using Api.Database.Entity;
using Api.Database.Entity.Enquiries;
using Api.Domain.Enquiries;
using Swc.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Api.Database.Entity.Crm;
using Api.Database.Entity.Inventory.Products;

namespace ViewModel
{
    public class EnquiryViewModel : ViewModelBase
    {
        private IEnquiriesService _repository;
        private Enquiry _currentEnquiry;
        private Contact _currentContact;
        private MarketingZone _currentMarketingZone;
        private EnquiryProduct _enquiryProduct,_SelectedDataGridProduct, _FinanceEnquiryProduct;
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
            EnquiryProducts = new ObservableCollection<EnquiryProduct>(eq.EnquiryProducts);
            CurrentFinanceQuotation = new EnquiryFinanceQuotation();
            CurrentExchangeQuotation = new EnquiryExchangeQuotation();
            CurrentFinanceEnquiryProduct =EnquiryProducts.FirstOrDefault();
            ExchangeQuotations = new ObservableCollection<EnquiryExchangeQuotation>(eq.EnquiryExchangeQuotations);
            CurrentExchangeQuotation = ExchangeQuotations.FirstOrDefault();
            Mode = ScreenOpenMode.Edit;
        }
        private void GeneralInitilize()
        {
            _repository = new addon.BikeShowRoomService.WebService.EnquiriesService();

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
            CurrentEnquiryProduct.Product = EnquiryMasterData.Products.FirstOrDefault();

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

            AddEnquiryProduct();
            CurrentFinanceEnquiryProduct = EnquiryProducts.FirstOrDefault();

        }
        #region Commands
        private void WireCommands()
        {
            UpdateEnquiryCommand = new RelayCommand(UpdateEnquiry);
            SaveEnquiryCommand = new RelayCommand(SaveEnquiry);
            FindEnquiryCommand = new RelayCommand(FindEnquiry);
            AddEnquiryProductCommand = new RelayCommand(AddEnquiryProduct);
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
        public RelayCommand AddEnquiryProductCommand
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

        private ObservableCollection<EnquiryProduct> _enquiryProducts;
        public ObservableCollection<EnquiryProduct> EnquiryProducts
        {
            get
            {
                return _enquiryProducts;
            }
            set
            {
                _enquiryProducts = value;
                OnPropertyChanged("EnquiryProducts");
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
        public EnquiryProduct CurrentEnquiryProduct
        {
            get
            {
                return _enquiryProduct;
            }

            set
            {
                if (_enquiryProduct != value)
                {
                    _enquiryProduct = value;
                    OnPropertyChanged("CurrentEnquiryProduct");

                    AddEnquiryProductCommand.IsEnabled = true;
                }
            }
        }
        public EnquiryProduct SelectedDataGridProduct
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
        public EnquiryProduct CurrentFinanceEnquiryProduct
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
            insertEnquiryModel.EnquiryProducts = EnquiryProducts;
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

            if (_enquiryProduct == null)
                return false;

            return true;
        }
        void InitInsert()
        {
            CurrentEnquiry = new Enquiry() { EnquiryDate = CurrentEnquiry==null?System.DateTime.Now:CurrentEnquiry.EnquiryDate };
            CurrentContact = new Contact();
            CurrentEnquiryProduct = new EnquiryProduct();
            CurrentEnquiryProduct.Product = new Product();
            CurrentFinanceQuotation = new EnquiryFinanceQuotation();
            CurrentExchangeQuotation = new EnquiryExchangeQuotation();

            EnquiryProducts=new ObservableCollection<EnquiryProduct>();
            
            ExchangeQuotations = new ObservableCollection<EnquiryExchangeQuotation>();
            
        }
        void ClearData()
        {
            InitInsert();
            EnquiryProducts.Clear();
            ExchangeQuotations.Clear();
        }
        public void FindEnquiry()
        {
        }
       
        public void AddEnquiryProduct()
        {
            if (!InsertValidation())
                return;

            EnquiryProduct enquiryProduct = new EnquiryProduct();
            enquiryProduct.Product = _enquiryProduct.Product;
            enquiryProduct.ProductId = _enquiryProduct.Product.Id;

            enquiryProduct.OnRoadPrice = _enquiryProduct.Product.Price;
            enquiryProduct.AccessoriesAmount = _enquiryProduct.AccessoriesAmount;
            enquiryProduct.OtherAmount = _enquiryProduct.OtherAmount;
            enquiryProduct.TotalAmount = enquiryProduct.OnRoadPrice + enquiryProduct.AccessoriesAmount+enquiryProduct.OtherAmount;

            EnquiryProducts.Add(enquiryProduct);
            CurrentEnquiryProduct = new EnquiryProduct();
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
            EnquiryProducts.Remove(SelectedDataGridProduct);
        }
        public void RemoveFinanceQuotationRow()
        {
            CurrentFinanceEnquiryProduct.EnquiryFinanceQuotations.Remove(SelectedDataGridFinanceQuotation);
        }
    }
   

}
