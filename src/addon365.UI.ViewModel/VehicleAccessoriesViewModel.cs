using addon365.Database.Entity.Inventory.Catalog;
using addon365.IService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace addon365.UI.ViewModel
{
    public class VehicleAccessoriesViewModel : ViewModelBase
    {
        private readonly IProductService _repositoryProduct;
        private bool EditMode = false;
        private readonly IAccessoriesService _accessoriesService;
        private CatalogItem _currentSelectedVehicle, _currentSelectedAccessories;
        private ExtraFittingsAccessories _currentFitting, _currentSelectedGridFitting;
        private CatalogBrand _productCompany;
        private bool _isProductSelected;
        public VehicleAccessoriesViewModel()
        {
            var Scope = Startup.Instance.provider.CreateScope();
            _repositoryProduct = Scope.ServiceProvider.GetRequiredService<IProductService>();
            _accessoriesService = Scope.ServiceProvider.GetRequiredService<IAccessoriesService>();
            Bikes = _repositoryProduct.GetProductByType(100);
            Accessories = _repositoryProduct.GetProductByType(200);
           
            WireCommands();
            CurrentFitting = new ExtraFittingsAccessories();
            DeleteCommand.IsEnabled = true;
            IsProductSelected = false;
            
        }
        private void WireCommands()
        {
            SaveCommand = new RelayCommand(SaveAccessories);
            DeleteCommand = new RelayCommand(DeleteAccessories);
            AddCommand = new RelayCommand(AddFittings);
        }
        public RelayCommand DeleteCommand
        {
            get;
            private set;
        }
        public RelayCommand AddCommand
        {
            get;
            private set;
        }
        public RelayCommand SaveCommand
        {
            get;
            private set;
        }
        public IEnumerable<CatalogItem> Bikes { get; set; }

        public IEnumerable<CatalogItem> Accessories { get; set; }

        private ObservableCollection<ExtraFittingsAccessories> _extraFittings;
        public ObservableCollection<ExtraFittingsAccessories> ExtraFittings
        {
            get
            {
                return _extraFittings;
            }
            set
            {
                _extraFittings = value;
                OnPropertyChanged("ExtraFittings");
            }
        }
       
        public bool IsProductSelected
        {
            get
            {
                return _isProductSelected;
            }
            set
            {
                _isProductSelected = value;
                OnPropertyChanged("IsProductSelected");
            }
        }
        public CatalogItem CurrentSelectedVehicle
        {
            get
            {
                return _currentSelectedVehicle;
            }

            set
            {

                _currentSelectedVehicle = value;
                IsProductSelected = true;
                GetFittings(_currentSelectedVehicle.Id);
                OnPropertyChanged("CurrentSelectedVehicle");
                


            }
        }
        public CatalogItem CurrentSelectedAccessories
        {
            get
            {
                return _currentSelectedAccessories;
            }

            set
            {

                _currentSelectedAccessories = value;

                OnPropertyChanged("CurrentSelectedAccessories");



            }
        }
        public ExtraFittingsAccessories CurrentFitting
        {
            get
            {
                return _currentFitting;
            }

            set
            {

                _currentFitting = value;
                AddCommand.IsEnabled = true;
                OnPropertyChanged("CurrentFitting");



            }
        }
        public ExtraFittingsAccessories CurrentSelectedGridFitting
        {
            get
            {
                return _currentSelectedGridFitting;
            }

            set
            {

                _currentSelectedGridFitting = value;

                OnPropertyChanged("CurrentSelectedFitting");



            }
        }


        public void SaveAccessories()
        {
            if(!EditMode)
                _accessoriesService.InsertAccessories(ExtraFittings);
            else
                _accessoriesService.UpdateAccessories(ExtraFittings);
        }
        public void GetFittings(Guid ProductId)
        {
           ExtraFittings= new ObservableCollection<ExtraFittingsAccessories>(_accessoriesService.GetAccessories(ProductId));

            if(ExtraFittings.Count>0)
            {
                ExtraFittings.First().UnitPrice = 600;
                EditMode = true;
            }
        }
        public void DeleteAccessories()
        {
            _accessoriesService.DeleteAccessories(CurrentSelectedGridFitting.Id);
            
        }
        public void AddFittings()
        {
            if (ExtraFittings == null)
                ExtraFittings = new ObservableCollection<ExtraFittingsAccessories>();

            SaveCommand.IsEnabled = true;
            CurrentFitting.AccessoriesProductId = CurrentSelectedAccessories.Id;
            CurrentFitting.AccessoriesProductItem = CurrentSelectedAccessories;
            CurrentFitting.CatalogItemId = CurrentSelectedVehicle.Id;
            CurrentFitting.CatalogItem = CurrentSelectedVehicle;

            ExtraFittings.Add(CurrentFitting);
            CurrentSelectedAccessories = null;
        }


    }
}
