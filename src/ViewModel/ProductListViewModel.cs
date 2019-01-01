using addon.BikeShowRoomService.WebService;
using Api.Database.Entity.Products;
using Api.Domain.Paging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            PagingViewModel = new PagingViewModel<Product>(new Func<Api.Domain.Paging.PagingParams, Threenine.Data.Paging.IPaginate<Product>>(RefreshData));
            
            
            WireCommands();
            DeleteCommand.IsEnabled = true;
        }
        private Threenine.Data.Paging.IPaginate<Product> RefreshData(PagingParams pagingParams)
        {

            return _repositoryProduct.GetAllActive(pagingParams);
            
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

        public PagingViewModel<Product> PagingViewModel { get; private set; }
        
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
            try
            {
                Product p = CurrentProduct;
                _repositoryProduct.Delete(p);
                if (msg != null)
                    msg.ShowUI("Delete Successfully");

                PagingViewModel.RefreshData();
            }
            catch(Exception ex)
            { 
                if (msg != null)
                msg.ShowUI(ex.Message);
            }

        }
        public IMsgBox msg { get; set; }
    }

}
