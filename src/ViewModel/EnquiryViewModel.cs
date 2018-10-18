﻿
using Api.Database.Entity;
using Api.Database.Entity.Enquiries;
using Api.Database.Entity.Products;
using Api.Domain.Enquiries;
using Swc.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Threenine.Data;
using System.Linq;
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

            EnquiryMasterData = _repository.GetInitilizeEnquiries();
            WireCommands();
            InitInsert();
            InitDefaultValues();
        }
        [Conditional("DEBUG")]
        private void InitDefaultValues()
        {

            CurrentEnquiry = new Api.Domain.Enquiries.Enquiries
            {
                Name = "User",
                Address = "14,street, Choolaimedu ",
                MobileNumber = "9645645666",
                Identifier = "Identifier1",
                Place = "Choolaimedu"
            };

            CurrentEnquiryProduct = EnquiryMasterData.Products.FirstOrDefault();

            CurrentFinanceQuotation = new EnquiryFinanceQuotation
            {
                DownPayment = 222,
                EMIAmount = 3333,
                TenureInMonths = 12,
            };
            CurrentExchangeQuotation = new EnquiryExchangeQuotation
            {
                Expected = 22333.66,
                Model = "Indigo",
                NoOfOwner = 1,
                Year = 2000,
                Quotated = 55676,
                

            };
            CurrentMarketingZone = EnquiryMasterData.MarketingZones.FirstOrDefault();

            AddEnquiryProduct();

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
        public ObservableCollection<EnquiryProduct> EnquiryProducts
        {
            get
            { return _enquiryProducts; }
            set { _enquiryProducts = value; }
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
        public async void InsertEnquiry()
        {

            if (!InsertValidation())
                return;

            InsertEnquiryCommand.IsEnabled = false;

            if (CurrentExchangeQuotation.Model != "")
            {
                AddExchangeQuotation();
            }
            InsertEnquiryModel insertEnquiryModel = new InsertEnquiryModel();
            insertEnquiryModel.Enquiry = CurrentEnquiry;
            insertEnquiryModel.EnquiryProducts = EnquiryProducts;
            insertEnquiryModel.enquiryFinanceQuotations = FinanceQuotations;
            insertEnquiryModel.enquiryExchangeQuotations = ExchangeQuotations;

            await _repository.Insert(insertEnquiryModel);


            InitInsert();
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

            CurrentFinanceQuotation.ProductId = CurrentEnquiryProduct.Id;
            FinanceQuotations.Add(CurrentFinanceQuotation);
        }
        public void AddExchangeQuotation()
        {

            ExchangeQuotations.Clear();
            ExchangeQuotations.Add(CurrentExchangeQuotation);
        }
    }


}
