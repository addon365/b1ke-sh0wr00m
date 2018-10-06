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

        public ProductViewModel()
        {
            currentProduct = new Product();
            _repositoryProduct = new ProductService();
            WireCommands();
        }
        private void WireCommands()
        {

            InsertCommand = new RelayCommand(AddEnquiry);
           
        }
        public RelayCommand InsertCommand
        {
            get;
            private set;
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
        public void AddEnquiry()
        {
            _repositoryProduct.Insert(CurrentProduct);
        }
    }
}
