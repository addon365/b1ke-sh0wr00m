using addon.BikeShowRoomService.WebService;
using Api.Database.Entity.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
  public class BikeAccessoriesViewModel : ViewModelBase
    {
        private readonly ProductService _repositoryProduct;
        private Product _currentProduct;
        private ProductCompany _productCompany;

        public BikeAccessoriesViewModel()
        {
            _repositoryProduct = new ProductService();
            Bikes = _repositoryProduct.GetProductByType(100);
            Accessories = _repositoryProduct.GetProductByType(200);

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

        public IEnumerable<Product> Bikes{ get; set; }

        public IEnumerable<Product> Accessories { get; set; }

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
