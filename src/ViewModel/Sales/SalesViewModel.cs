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
using Swc.Service.Sales;
using Api.Domain.Sales;
using Api.Database.Entity.Sales;
using Api.Database.Entity.Crm;
using Api.Database.Entity.Accounts;
using System.ComponentModel;
using System.Reflection;

namespace ViewModel.Sales
{
    public class SalesViewModel : ViewModelBase
    {
        private readonly ISalesService _repository;
        private MarketingZone _currentMarketingZone;
        private Product _currentVehicle;
        private Customer _currentCustomer;
        private VoucherInfo _currentAmount;

        public InitilizeSales MasterData { get; }


        public SalesViewModel()
        {
            _repository = new addon.BikeShowRoomService.WebService.SalesService();

            MasterData = _repository.GetInitilizeSales();
            WireCommands();
            Init();
           
        }
        void Init()
        {
            InsertCommand.IsEnabled = true;
            CurrentCustomer = new Customer();
            CurrentCustomer.Profile = new Contact();
            CurrentAmount = new VoucherInfo();
            Amounts = new ObservableCollection<VoucherInfo>();
        }
        void LoadData()
        {
            CurrentCustomer.Profile.Name = "Ram";
        }
        #region Commands
        private void WireCommands()
        {
            InsertCommand = new RelayCommand(Insert);
            AddAmountCommand = new RelayCommand(AddAmount);
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
        public RelayCommand AddAmountCommand
        {
            get;
            private set;
        }
        public RelayCommand FindCommand
        {
            get;
            private set;
        }
       void Insert()
        {
            if (!Validate())
            {
                if (MsgBox != null)
                    MsgBox.ShowUI("Incomplete Form, check all data");

                return;
            }

            InsertSalesModel model = new InsertSalesModel();
            SaleMaster sm = new SaleMaster();
            sm.CustomerId = CurrentCustomer.Id;
            sm.Customer = CurrentCustomer;
            
            SalesInventorys salesInventorys = new SalesInventorys();
            salesInventorys.ProductId = CurrentVehicle.Id;
            salesInventorys.UnitPrice =45000;
            List<SalesInventorys> inventorys = new List<SalesInventorys>();
            inventorys.Add(salesInventorys);

            model.Sales = sm;
            model.Inventorys = inventorys;

            model.Amounts = Amounts;
            _repository.Insert(model);

        }
        bool Validate()
        {
            bool result = true; 
            if(CurrentCustomer==null)
            {
                result =false;
            }
            if(CurrentVehicle==null)
            {
                result = false;
            }
            return result;
        }
        #endregion

        public  VoucherInfo CurrentAmount
        {
            get
            {
                return _currentAmount;
            }
            set
            {
                if(_currentAmount!=value)
                {

                    _currentAmount = value;

                    OnPropertyChanged("CurrentAmount");
                    AddAmountCommand.IsEnabled = true;
                }
            }
        }
        private ObservableCollection<VoucherInfo> _Amounts;
        public ObservableCollection<VoucherInfo> Amounts
        {
            get
            {
                return _Amounts;
            }
            set
            {
                _Amounts = value;
                OnPropertyChanged("Amounts");
            }
        }
        public void AddAmount()
        {

            CurrentAmount.FieldInfo = AccountFields.CashAmount.ToString();
            string str = AccountFields.CashAmount.DescriptionAttr();
            Amounts.Add(CurrentAmount);
        }
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
        public Product CurrentVehicle
        {
            get
            {
                return _currentVehicle;
            }

            set
            {
                if (_currentVehicle != value)
                {
                    _currentVehicle = value;
                    OnPropertyChanged("CurrentVehicle");
 
                   
                }
            }
        }
        public IMsgBox MsgBox { get; set; }
        public Customer CurrentCustomer
        {
            get
            {
                
                return _currentCustomer;
            }

            set
            {
                if (_currentCustomer != value)
                {
                    _currentCustomer = value;
                    OnPropertyChanged("CurrentCustomer");


                }
            }

        }
      
    }
    enum AccountFields{None,
        [Description("Cash")]CashAmount, CardAmount}


}
