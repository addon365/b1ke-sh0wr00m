﻿
using addon365.Database.Entity;
using addon365.Database.Entity.Enquiries;
using addon365.Database.Entity.Inventory.Catalog;
using addon365.Domain.Entity.Enquiries;
using addon365.Database.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using addon365.IService;
using Microsoft.Extensions.DependencyInjection;

namespace addon365.UI.ViewModel
{
    public class VehicleSaleViewModel : ViewModelBase
    {
        private readonly IEnquiriesService _repository;
        private Enquiry _currentEnquiry;
        private MarketingZone _currentMarketingZone;
        private CatalogItem _enquiryProduct;
        private EnquiryFinanceQuotation _financeQuotation;
        private EnquiryExchangeQuotation _exchangeQuotation;
        public VehicleSaleViewModel()
        {
            var Scope = Startup.Instance.provider.CreateScope();
            _repository = Scope.ServiceProvider.GetRequiredService<IEnquiriesService>();


            EnquiryMasterData =  _repository.GetInitilizeEnquiries();
            WireCommands();
            InitInsert();
        }
  

        #region Commands
        private void WireCommands()
        {
            UpdateCommand = new RelayCommand(Update);
            InsertCommand = new RelayCommand(Insert);
            FindEnquiryCommand = new RelayCommand(FindEnquiry);
            AddEnquiryProductCommand = new RelayCommand(AddEnquiryProduct);
            AddFinanceQuotationCommand = new RelayCommand(AddFinanceQuotation);

        }


        public RelayCommand UpdateCommand
        {
            get;
            private set;
        }
        public RelayCommand InsertCommand
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
            }
        }
   

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
                    InsertCommand.IsEnabled = true;
                    FindEnquiryCommand.IsEnabled = true;
                    UpdateCommand.IsEnabled = true;
                }
            }
        }
        public CatalogItem CurrentEnquiryProduct
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
        public void Update()
        {

        }
        public async void Insert()
        {

            if (!InsertValidation())
                return;

            InsertCommand.IsEnabled = false;

            if (CurrentExchangeQuotation.Model != "")
            {
                AddExchangeQuotation();
            }
            InsertEnquiryModel insertEnquiryModel = new InsertEnquiryModel();
            insertEnquiryModel.Enquiry = CurrentEnquiry;
            insertEnquiryModel.EnquiryItems = EnquiryItems;
            insertEnquiryModel.enquiryExchangeQuotations = ExchangeQuotations;

            await _repository.Insert(insertEnquiryModel);


            ClearData();


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
            CurrentEnquiry = new Enquiry();
            CurrentEnquiryProduct = new CatalogItem();
            CurrentFinanceQuotation = new EnquiryFinanceQuotation();
            CurrentExchangeQuotation = new EnquiryExchangeQuotation();

            _enquiryItems=new ObservableCollection<EnquiryCatalogItem>();
        }
        void ClearData()
        {
            InitInsert();
            EnquiryItems.Clear();
        }
        public void FindEnquiry()
        {
         
        }
        
        public void AddEnquiryProduct()
        {
            if (!InsertValidation())
                return;

            EnquiryCatalogItem enquiryProduct = new EnquiryCatalogItem();
            enquiryProduct.Item = _enquiryProduct;
            enquiryProduct.CatalogItemId = _enquiryProduct.Id;

            enquiryProduct.OnRoadPrice = _enquiryProduct.Price;
            enquiryProduct.AccessoriesAmount = 0;
            enquiryProduct.TotalAmount = enquiryProduct.OnRoadPrice + enquiryProduct.AccessoriesAmount;

            EnquiryItems.Add(enquiryProduct);
        }
        public void AddFinanceQuotation()
        {

            //CurrentFinanceQuotation.ProductId = CurrentEnquiryProduct.Id;
            FinanceQuotations.Add(CurrentFinanceQuotation);
        }
        public void AddExchangeQuotation()
        {

            ExchangeQuotations.Clear();
            ExchangeQuotations.Add(CurrentExchangeQuotation);
        }
    }


}
