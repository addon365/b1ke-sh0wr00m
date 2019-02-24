using addon365.WebClient.Service.WebService;
using addon365.Database.Entity.Inventory.Products;
using System;
using System.Collections.Generic;

namespace addon365.UI.ViewModel
{
    public class ProductViewModel:ViewModelBase
    {
        private readonly ProductService _repositoryProduct;
        private Product currentProduct;
        private ProductCompany _productCompany;
        private ProductType _productType;
        public ProductViewModel()
        {
            try
            {
                _repositoryProduct = new ProductService();
                currentProduct = new Product();
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

        public IEnumerable<ProductCompany> ProductCompanies { get; set; }
        public IEnumerable<ProductType> ProductTypes { get; set; }

        public ProductCompany CurrentProductCompany
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
        public ProductType CurrentProductType
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
        public Product CurrentProduct
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

            CurrentProduct = new Product();
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
            Product p = new Product();
            p.ProductName = "Pulsor";
            p.Identifier = "00184";
            CurrentProduct = p;
        }
        
    }
}
