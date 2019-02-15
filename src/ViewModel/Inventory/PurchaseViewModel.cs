﻿using System;
using System.Diagnostics;
using Swc.Service.Inventory;
using Api.Domain.Inventory;
using Api.Database.Entity.Inventory.Purchases;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Api.Database.Entity.Inventory.Products;
using System.Data;
using Api.Database.Entity.Accounts;

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
        public PurchaseViewModel(Purchase purchase)
        {
            GeneralInitilize();
            CurrentPurchase = purchase;
            Items = new ObservableCollection<PurchaseItem>(purchase.Items);


            
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
            CurrentPurchase = new Purchase();
            CurrentItem = new PurchaseItem();
            _Items = new ObservableCollection<PurchaseItem>();

            InvoiceAmount = new VoucherInfo();
            InvoiceAmount.FieldInfo = FieldInfo.InvoiceAmount.ToString();
            InvoiceAmount.bookId = MasterData.PurchaseBook.Id;

            CashAmount = new VoucherInfo();
            CashAmount.FieldInfo = FieldInfo.CashAmount.ToString();
            CashAmount.bookId = MasterData.CashBook.Id;

            GstAmount = new VoucherInfo();
            GstAmount.FieldInfo = FieldInfo.GstAmount.ToString();
            GstAmount.bookId = MasterData.GstBook.Id;

            AddPropertyCommand.IsEnabled = true;
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
            AddItemCommand = new RelayCommand(AddItem);
            AddPropertyCommand = new RelayCommand(AddProperty);

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
                    InsertPurchase();
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
        public RelayCommand AddItemCommand
        {
            get;
            private set;
        }
        public void AddItem()
        {
            try
            {
                
                if (CurrentItem == null)
                    throw new Exception("Object Product not Created");

                if (CurrentItem.Product == null)
                    throw new Exception("No Product Selected");


             
                CurrentItem.ProductId = CurrentItem.Product.Id;
                

                Items.Add(CurrentItem); 
                CurrentItem = new PurchaseItem();
            }
            catch (Exception ex)
            {
                if (MessageBox != null)
                    MessageBox.ShowUI(ex.Message);
            }

        }
        public RelayCommand AddPropertyCommand
        {
            get;
            private set;
        }
        public void AddProperty()
        {
            if (CurrentItem.Product.Properties == null)
                return;

            if (CurrentItem.ItemPropertyMaps == null)
                CurrentItem.ItemPropertyMaps = new List<PurchaseItemPropertyMap>();

            
            var PItemPropertyMap = new PurchaseItemPropertyMap();
            PItemPropertyMap.PurchaseItemId = CurrentItem.Id;

            PItemPropertyMap.PropertyValues = new List<PurchaseItemPropertyValue>();
            foreach(ProductPropertiesMap ProMap in CurrentItem.Product.Properties)
            {
                PurchaseItemPropertyValue PropertyValue = new PurchaseItemPropertyValue();
                PropertyValue.ProductPropertyMasterId = ProMap.ProductPropertyMasterId;
                PropertyValue.ProductPropertyMaster = ProMap.PropertyMaster;
                PropertyValue.PurchaseItemPropertyMapId = PItemPropertyMap.Id;
                PItemPropertyMap.PropertyValues.Add(PropertyValue);

            }
            if(PItemPropertyMap.PropertyValues.Count>0)
            {
                PropertyValueViewModel pv = new PropertyValueViewModel(PItemPropertyMap.PropertyValues);
                PropertyWindow.ShowUI(pv);
                CurrentItem.ItemPropertyMaps.Add(PItemPropertyMap);
                OnPropertyChanged("PropertyValuesList");
            }

        }
        public IViewUI<PropertyValueViewModel> PropertyWindow { get; set; }
        #endregion
        private PurchaseMasterData _MasterData;
        public PurchaseMasterData MasterData
        {
            get
            {
                return _MasterData;
            }
        }
        
        public DataTable PropertyValuesList
        {
            get
            {
                if (CurrentItem.ItemPropertyMaps == null)
                    return null;

                DataTable dt = new DataTable();
                foreach (ProductPropertiesMap ProMap in CurrentItem.Product.Properties)
                {
                    dt.Columns.Add(new DataColumn(ProMap.PropertyMaster.PropertyName));
                }
                foreach (PurchaseItemPropertyMap ItemMap in CurrentItem.ItemPropertyMaps)
                {
                    DataRow row = dt.NewRow();
                  
                    foreach (PurchaseItemPropertyValue val in ItemMap.PropertyValues)
                    {
                        if(dt.Columns.Contains(val.ProductPropertyMaster.PropertyName))
                        {
                            row[val.ProductPropertyMaster.PropertyName] = val.Value;
                        }
                    }
                    dt.Rows.Add(row);
                    
                }
                return dt;
            }
        }
        private PurchaseItem _CurrentItem;
        public PurchaseItem CurrentItem
        {
            get
            {
                return _CurrentItem;
            }

            set
            {
                if (_CurrentItem != value)
                {
                    _CurrentItem = value;
                    OnPropertyChanged("CurrentItem");
                    AddItemCommand.IsEnabled = true;
                   
                }
            }
        }
        private ObservableCollection<PurchaseItem> _Items;
        public ObservableCollection<PurchaseItem> Items
        {
            get
            {
                return _Items;
            }
            set
            {
                _Items = value;
                OnPropertyChanged("Items");
            }
        }
        public VoucherInfo InvoiceAmount{ get;set; }
        public VoucherInfo GstAmount { get; set; }
        public VoucherInfo CashAmount { get; set; }
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
        private async void InsertPurchase()
        {
            if (!InsertValidation())
                return;

            SaveCommand.IsEnabled = false;

            Voucher voucher = new Voucher();
            voucher.VoucherDate = System.DateTime.Now;
            voucher.VoucherTypeId = MasterData.VoucherTypeMaster.Id;

            ICollection<VoucherInfo> lstVoucherInfo = new List<VoucherInfo>();

            InvoiceAmount.VoucherId = voucher.Id;
            lstVoucherInfo.Add(InvoiceAmount);

            CashAmount.VoucherId = voucher.Id;
            lstVoucherInfo.Add(CashAmount);

            GstAmount.VoucherId = voucher.Id;
            lstVoucherInfo.Add(GstAmount);

            voucher.VoucherInfos = lstVoucherInfo;
            CurrentPurchase.Voucher = voucher;
            CurrentPurchase.VoucherId = voucher.Id;
            CurrentPurchase.Items = Items;
            await _repository.Insert(CurrentPurchase);

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
    enum FieldInfo { CashAmount,InvoiceAmount,GstAmount }

}