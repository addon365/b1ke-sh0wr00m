using addon365.WebClient.Service.WebService;
using addon365.Database.Entity.Inventory.Catalog;
using addon365.Domain.Entity.Paging;
using System;

namespace addon365.UI.ViewModel
{
    public class ProductListViewModel: ViewModelBase
    {
        private readonly ProductService _repositoryProduct;
        private CatalogItem _currentProduct;
        private CatalogBrand _productCompany;
        
        public ProductListViewModel()
        {
            _repositoryProduct = new ProductService();
            PagingViewModel = new PagingViewModel<CatalogItem>(new Func<addon365.Domain.Entity.Paging.PagingParams, Threenine.Data.Paging.IPaginate<CatalogItem>>(RefreshData));
            
            
            WireCommands();
            DeleteCommand.IsEnabled = true;
        }
        private Threenine.Data.Paging.IPaginate<CatalogItem> RefreshData(PagingParams pagingParams)
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

        public PagingViewModel<CatalogItem> PagingViewModel { get; private set; }
        
        public CatalogItem CurrentProduct
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
                CatalogItem p = CurrentProduct;
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
