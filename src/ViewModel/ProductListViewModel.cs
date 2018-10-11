using addon.BikeShowRoomService.WebService;
using Api.Database.Entity.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
  public class ProductListViewModel: ViewModelBase
    {
        private readonly ProductService _repositoryProduct;
        private Product _currentProduct;
        private ProductCompany _productCompany;

        public ProductListViewModel()
        {
            _repositoryProduct = new ProductService();
            Products = _repositoryProduct.GetAllActive();
            
            WireCommands();
            DeleteCommand.IsEnabled = true;
        }
        private void WireCommands()
        {

            DeleteCommand = new RelayCommand(DeleteProduct);
           
        }
        public RelayCommand DeleteCommand
        {
            get;
            private set;
        }

        public IEnumerable<Product> Products{ get; set; }
        
        public Product CurrentProduct
        {
            get
            {
                return _currentProduct;
            }

            set
            {

                _currentProduct = value;
                OnPropertyChanged("CurrentProduct");
                


            }
        }
      
        public void DeleteProduct()
        {
            Product p = CurrentProduct;
            _repositoryProduct.Delete(p);
            
        }
    }
}
