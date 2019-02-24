using addon365.WebClient.Service.WebService;
using addon365.Database.Entity.Inventory.Products;
using System.Collections.Generic;

namespace addon365.UI.ViewModel
{
    public class ProductCompanyViewModel:ViewModelBase
    {
        private readonly ProductCompanyService _repositoryProductCompany;
        private ProductCompany _productCompany;

        public ProductCompanyViewModel()
        {
            _productCompany = new ProductCompany();
            _repositoryProductCompany = new ProductCompanyService();
            ProductCompanies = _repositoryProductCompany.GetAllProductCompanies();
            WireCommands();
        }
        private void WireCommands()
        {

            InsertCommand = new RelayCommand(AddProductCompany);
            DeleteCommand = new RelayCommand(DeleteProductCompany);
        }
        public RelayCommand InsertCommand
        {
            get;
            private set;
        }
        public RelayCommand DeleteCommand
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
                InsertCommand.IsEnabled = true;


            }
        }
        public void AddProductCompany()
        {
            CurrentProductCompany.ProgrammerID = 1001;
            _repositoryProductCompany.Insert(CurrentProductCompany);
        }
        public void DeleteProductCompany()
        {
            ProductCompany p = CurrentProductCompany;
            _repositoryProductCompany.Delete(p);

        }
    }
}
