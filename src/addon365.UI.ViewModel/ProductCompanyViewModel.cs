using addon365.Database.Entity.Inventory.Catalog;
using addon365.IService;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace addon365.UI.ViewModel
{
    public class ProductCompanyViewModel:ViewModelBase
    {
        private readonly IProductCompanyService _repositoryProductCompany;
        private CatalogBrand _productCompany;

        public ProductCompanyViewModel()
        {
            var Scope = Startup.Instance.provider.CreateScope();

       
            _productCompany = new CatalogBrand();
            _repositoryProductCompany = Scope.ServiceProvider.GetRequiredService<IProductCompanyService>();
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
        public IEnumerable<CatalogBrand> ProductCompanies { get; set; }
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
            CatalogBrand p = CurrentProductCompany;
            _repositoryProductCompany.Delete(p);

        }
    }
}
