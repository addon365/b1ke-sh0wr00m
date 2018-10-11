using addon.BikeShowRoomService.WebService;
using Api.Database.Entity.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
  public class ProductViewModel:ViewModelBase
    {
        private readonly ProductService _repositoryProduct;
        private Product currentProduct;
        private ProductCompany _productCompany;

        public ProductViewModel()
        {
            currentProduct = new Product();
            _repositoryProduct = new ProductService();
            ProductCompanies = _repositoryProduct.GetCompanies();
            
            WireCommands();
        }
        private void WireCommands()
        {

            InsertCommand = new RelayCommand(AddProduct);
        }
        public RelayCommand InsertCommand
        {
            get;
            private set;
        }

        public IEnumerable<ProductCompany> ProductCompanies { get; set; }
        
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
       
        
        public void AddProduct()
        {
            CurrentProduct.CompanyId = CurrentProductCompany.Id;
            _repositoryProduct.Insert(CurrentProduct);
        }
    }
}
