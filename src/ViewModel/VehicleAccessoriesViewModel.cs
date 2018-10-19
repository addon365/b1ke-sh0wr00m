using addon.BikeShowRoomService.WebService;
using Api.Database.Entity.Products;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ViewModel
{
    public class VehicleAccessoriesViewModel : ViewModelBase
    {
        private readonly ProductService _repositoryProduct;
        private readonly AccessoriesService _accessoriesService;
        private Product _currentSelectedVehicle, _currentSelectedAccessories;
        private ExtraFittingsAccessories _currentFitting, _currentSelectedGridFitting;
        private ProductCompany _productCompany;
        private bool _isProductSelected;
        public VehicleAccessoriesViewModel()
        {
            _repositoryProduct = new ProductService();
            _accessoriesService = new AccessoriesService();
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
        public IEnumerable<Product> Bikes { get; set; }

        public IEnumerable<Product> Accessories { get; set; }

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
        public Product CurrentSelectedVehicle
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
        public Product CurrentSelectedAccessories
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

            _accessoriesService.InsertAccessories(ExtraFittings);
        }
        public void GetFittings(Guid ProductId)
        {
           ExtraFittings= new ObservableCollection<ExtraFittingsAccessories>(_accessoriesService.GetAccessories(ProductId));
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
            CurrentFitting.AccessoriesProducts = CurrentSelectedAccessories;
            CurrentFitting.ProductId = CurrentSelectedVehicle.Id;
            CurrentFitting.Product = CurrentSelectedVehicle;

            ExtraFittings.Add(CurrentFitting);
        }


    }
}
