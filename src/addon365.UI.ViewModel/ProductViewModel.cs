using addon365.Database.Entity.Inventory.Catalog;
using addon365.IService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace addon365.UI.ViewModel
{
    public class ProductViewModel:ViewModelBase
    {
        private readonly IProductService _repositoryProduct;
        private CatalogItem currentProduct;
        private CatalogBrand _productCompany;
        private CatalogType _productType;
        public ProductViewModel()
        {
            try
            {
                var Scope = Startup.Instance.provider.CreateScope();

                _repositoryProduct = Scope.ServiceProvider.GetRequiredService<IProductService>();
                currentProduct = new CatalogItem();
                InitInsert();

                WireCommands();
            }
            catch (Exception ex)
            { throw ex; }
        }
        private void InitInsert()
        {
            ProductCompanies = _repositoryProduct.GetCompanies();
            ProductTypes = _repositoryProduct.GetTypes();
        }
        private void WireCommands()
        {
            InsertCommand = new RelayCommand(AddProduct);
            InsertTypeCommand= new RelayCommand(AddProductType);
        }
        public RelayCommand InsertCommand
        {
            get;
            private set;
        }
        public RelayCommand InsertTypeCommand
        {
            get;
            private set;
        }

        public IEnumerable<CatalogBrand> ProductCompanies { get; set; }
        public IEnumerable<CatalogType> ProductTypes { get; set; }

        public CatalogBrand CurrentProductCompany
        {
            get
            {
                return _productCompany;
            }
            set
            {
                _productCompany = value;
                OnPropertyChanged("CurrentProductCompany");
            }
        }
        public CatalogType CurrentProductType
        {
            get
            {
                return _productType;
            }
            set
            {
                _productType = value;
                OnPropertyChanged("CurrentProductType");
                InsertTypeCommand.IsEnabled =true ;
            }
        }
        public CatalogItem CurrentProduct
        {
            get
            {
                return currentProduct;
            }

            set
            {
                currentProduct = value;
                OnPropertyChanged("CurrentProduct");
                InsertCommand.IsEnabled = true;
            }
        }
       
        public void AddProductType()
        {
            _repositoryProduct.InsertProductType(CurrentProductType);
        }
        public void AddProduct()
        {

            if (!ValidateProduct())
                return;

            InsertCommand.IsEnabled = false;
            CurrentProduct.CompanyId = CurrentProductCompany.Id;

            CurrentProduct.TypeId = CurrentProductType.Id;
            _repositoryProduct.Insert(CurrentProduct);

            CurrentProduct = new CatalogItem();
            InitInsert();

        }
        private bool ValidateProduct()
        {

            if (CurrentProduct == null)
                return false;

            if (CurrentProductCompany == null)
                return false;

            if (CurrentProductType == null)
                return false;

            return true;
        }
        private void LoadData()
        {
            CatalogItem p = new CatalogItem();
            p.ItemName = "Pulsor";
            p.Identifier = "00184";
            CurrentProduct = p;
        }
        
    }
}
