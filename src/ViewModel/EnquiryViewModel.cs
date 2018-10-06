
using Api.Database.Entity;
using Api.Database.Entity.Enquiries;
using Api.Database.Entity.Products;
using Api.Domain.Enquiries;
using Swc.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Threenine.Data;

namespace ViewModel
{
    public class EnquiryViewModel : ViewModelBase
    {
        private readonly IEnquiriesService _repository;
        private Enquiries _currentEnquiry;
        private MarketingZone _currentMarketingZone;
        private Product _enquiryProduct;
        private EnquiryFinanceQuotation _financeQuotation;
        private EnquiryExchangeQuotation _exchangeQuotation;
        public EnquiryViewModel()
        {
            _repository = new addon.BikeShowRoomService.WebService.EnquiriesService();

            EnquiryMasterData=_repository.GetInitilizeEnquiries();
            WireCommands();
            initInsert();
        }
        #region Commands
        private void WireCommands()
        {
            UpdateEnquiryCommand = new RelayCommand(UpdateEnquiry);
            InsertEnquiryCommand = new RelayCommand(InsertEnquiry);
            FindEnquiryCommand = new RelayCommand(FindEnquiry);
            AddEnquiryProductCommand = new RelayCommand(AddEnquiryProduct);
            AddFinanceQuotationCommand = new RelayCommand(AddFinanceQuotation);
          
        }
        
     
        public RelayCommand UpdateEnquiryCommand
        {
            get;
            private set;
        }
        public RelayCommand InsertEnquiryCommand
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
        public InitilizeEnquiry EnquiryMasterData { get; }
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
        private ObservableCollection<EnquiryProduct> _enquiryProducts = new ObservableCollection<EnquiryProduct>();
        public ObservableCollection<EnquiryProduct> EnquiryProducts { get
            { return _enquiryProducts; } set { _enquiryProducts = value; } }

        private ObservableCollection<EnquiryFinanceQuotation> _enquiryFinanceQuotations = new ObservableCollection<EnquiryFinanceQuotation>();
        public ObservableCollection<EnquiryFinanceQuotation> FinanceQuotations
        {
            get
            { return _enquiryFinanceQuotations; }
            set { _enquiryFinanceQuotations = value; }
        }

        private ObservableCollection<EnquiryExchangeQuotation> _enquiryExchangeQuotations = new ObservableCollection<EnquiryExchangeQuotation>();
        public ObservableCollection<EnquiryExchangeQuotation> ExchangeQuotations
        {
            get
            { return _enquiryExchangeQuotations; }
            set { _enquiryExchangeQuotations = value; }
        }

    
        public IEnumerable<EnquiryAccessories> enquiryAccessories { get; set; }

        public Enquiries CurrentEnquiry
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
                    InsertEnquiryCommand.IsEnabled = true;
                    FindEnquiryCommand.IsEnabled = true;
                    UpdateEnquiryCommand.IsEnabled = true;
                }
            }
        }
        public Product CurrentEnquiryProduct
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
        public void UpdateEnquiry()
        {
           
        }
        public void InsertEnquiry()
        {

            if (!InsertValidation())
                return;

           if(CurrentExchangeQuotation.Model!="")
            {
                AddExchangeQuotation();
            }
            InsertEnquiryModel insertEnquiryModel = new InsertEnquiryModel();
            insertEnquiryModel.Enquiry = CurrentEnquiry;
            insertEnquiryModel.EnquiryProducts = EnquiryProducts;
            insertEnquiryModel.enquiryFinanceQuotations = FinanceQuotations;
            insertEnquiryModel.enquiryExchangeQuotations = ExchangeQuotations;
            
            _repository.Insert(insertEnquiryModel);
            ClearEnquiry();
        }
        void ClearEnquiry()
        {

            CurrentEnquiry = new Enquiries();

        }
        bool InsertValidation()
        {
            if (_currentEnquiry == null)
                return false;

            if (_enquiryProduct == null)
                return false;

            return true;
        }
        void initInsert()
        {

            CurrentEnquiry = new Api.Domain.Enquiries.Enquiries();
            CurrentEnquiryProduct = new Product();
            CurrentFinanceQuotation = new EnquiryFinanceQuotation();
            CurrentExchangeQuotation = new EnquiryExchangeQuotation();
        }
        public void FindEnquiry()
        {
            LoadEnquiryData();
        }
        void LoadEnquiryData()
        {
            Enquiries enquiries = new Enquiries();
            enquiries.Name = "santhosh";
            enquiries.Address = "Walajapet";
            enquiries.MobileNumber = "9894496128";
            CurrentEnquiry = enquiries;
           
        }
        public void AddEnquiryProduct()
        {
            EnquiryProduct enquiryProduct = new EnquiryProduct();
            enquiryProduct.product = _enquiryProduct;
            enquiryProduct.ProductId = _enquiryProduct.Id;

            EnquiryProducts.Add(enquiryProduct);
        }
        public void AddFinanceQuotation()
        {
 

            FinanceQuotations.Add(CurrentFinanceQuotation);
        }
        public void AddExchangeQuotation()
        {

            ExchangeQuotations.Clear();
            ExchangeQuotations.Add(CurrentExchangeQuotation);
        }
    }

 
}
