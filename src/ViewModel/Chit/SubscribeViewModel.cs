using addon.BikeShowRoomService.WebService.Chit;
using Api.Database.Entity.Chit;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Api.Domain.Chit;
using Swc.Service.Chit;
using SchemeClientService = addon.BikeShowRoomService.WebService.Chit.SchemeService;
using Api.Database.Entity.Crm;

namespace ViewModel.Chit
{
    public class SubscribeViewModel : ViewModelBase
    {
        public ChitSubscribeDomain _chitSubscribeDomain;
        public IList<ChitScheme> _schemes;
        private ChitScheme _selectedScheme;
        private double _schemeAmount;
        private ISchemeService _schemeService;
        private IChitDueService _dueService;
        private ISubscribeService _subscribeService;
        private IList<Customer> _customers;
        private Customer _selectedCustomer;
        private string _customerName;
        private string _mobileNumber;
        private string _address;

        public SubscribeViewModel()
        {
            WireCommands();

            ChitSubscribe = new ChitSubscribeDomain();
            _dueService = new ChitDueClientService();
            _subscribeService = new SubsriberService();
            FetchSchemesAsync();
            FindAllCustomersAsync();
        }
        public ChitSubscribeDomain ChitSubscribe
        {
            get
            {
                return _chitSubscribeDomain;
            }
            set
            {
                if (ChitSubscribe != value)
                {
                    _chitSubscribeDomain = value;
                    OnPropertyChanged("ChitSubscribe");
                    SaveCommand.IsEnabled = true;
                }
            }
        }
        public virtual void WireCommands()
        {
            SaveCommand = new RelayCommand(Save);
        }
        public virtual void Save()
        {
            ChitSubscribe.CustomerName = CustomerName;
            ChitSubscribe.MobileNumber = MobileNumber;
            ChitSubscribe.Address = Address;
            if(SelectedCustomer!=null)
                ChitSubscribe.CustomerId = SelectedCustomer.Id;
            if (!Validate()) return;
            IsProgressBarVisible = true;
            try
            {
                var result = _dueService.Save(ChitSubscribe);
                Message = "Saved Successfullly and id is " + result.ChitSubscriber.SubscribeId;
                ChitSubscribe = new ChitSubscribeDomain();
                SaveCommand.IsEnabled = false;
            }
            catch (Exception exception)
            {
                SayMessage(false, exception.Message);
            }
            IsProgressBarVisible = false;
        }
        public RelayCommand SaveCommand
        {
            get;
            private set;
        }
        public double SchemeAmount
        {
            get { return _schemeAmount; }
            set
            {
                if (_schemeAmount != value)
                {
                    _schemeAmount = value;
                    OnPropertyChanged("SchemeAmount");
                }
            }
        }
        public IList<Customer> Customers
        {
            get
            {
                return _customers;
            }
            set
            {
                if (Customers != value)
                {
                    _customers = value;
                    OnPropertyChanged("Customers");
                }
            }
        }
        public Customer SelectedCustomer
        {
            get
            {
                return _selectedCustomer;
            }
            set
            {
                if (SelectedCustomer != value)
                {
                    _selectedCustomer = value;
                    OnPropertyChanged("SelectedCustomer");
                    CustomerName = SelectedCustomer.Profile.FirstName;
                    MobileNumber = SelectedCustomer.Profile.MobileNumber;
                    Address = SelectedCustomer.Profile.Address;
                    ChitSubscribe.CustomerId = SelectedCustomer.Id;
                }
            }
        }
        public ChitScheme SelectedScheme
        {
            get
            {
                return _selectedScheme;
            }
            set
            {
                if (_selectedScheme != value)
                {
                    _selectedScheme = value;
                    OnPropertyChanged("SelectedScheme");
                    ChitSubscribe.ChitSchemeId = _selectedScheme.Id;
                    ChitSubscribe.Amount = _selectedScheme.MonthlyAmount;
                    SchemeAmount = _selectedScheme.MonthlyAmount;
                }
            }
        }
        public IList<ChitScheme> Schemes
        {
            get
            {
                return _schemes;
            }
            set
            {
                if (_schemes != value)
                {
                    _schemes = value;
                    OnPropertyChanged("Schemes");
                }
            }
        }
        public void FetchSchemesAsync()
        {
            if (_schemeService == null)
            {
                _schemeService = new SchemeClientService();
            }
            Task task = new Task(
                () => Schemes = _schemeService.FindAll().ToList());
            task.Start();
        }
        private async void FindAllCustomersAsync()
        {
            IsProgressBarVisible = true;
            Message = "Loading Customer names...";

            var customers = await Task.Run(
                () =>
            _subscribeService.FindAllCustomers()
            );

            customers.Insert(0, new Customer()
            {
                Id = Guid.Empty,
                Profile = new Contact()
                {
                    FirstName = "Existing Customers"
                }
            });
            Customers = customers;
            Message = "Done Loading Customer names...";
            IsProgressBarVisible = false;
        }
        public bool Validate()
        {
            Message = "";
            string mobileNumber = ChitSubscribe.MobileNumber;
            if (mobileNumber == null || (mobileNumber != null && mobileNumber.Length < 10))
            {
                Message = "Mobile Number not valid";
                return false;
            }
            double amount = ChitSubscribe.Amount;
            if (amount == 0 || amount < 0)
            {
                Message = "Amount should be greater than zero";
                return false;
            }

            Guid chitSchemeId = ChitSubscribe.ChitSchemeId;
            if (chitSchemeId == null || chitSchemeId == Guid.Empty)
            {
                Message = "Choose a Schema.";
                return false;
            }
            string name = ChitSubscribe.CustomerName;
            if (name == null || (name != null && name.Length < 4))
            {
                Message = "Name must have atleast 5 letters.";
                return false;
            }

            return true;
        }
        public void SayMessage(bool isSuccess, string message)
        {
            Message = message;
        }

        public string CustomerName
        {
            get
            {
                return _customerName;
            }
            set
            {
                if (CustomerName != value)
                {
                    _customerName = value;
                    OnPropertyChanged("CustomerName");
                }
            }
        }
        public string MobileNumber
        {
            get
            {
                return _mobileNumber;
            }
            set
            {
                if (MobileNumber != value)
                {
                    _mobileNumber = value;
                    OnPropertyChanged("MobileNumber");
                }
            }
        }
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                if (Address != value)
                {
                    _address = value;
                    OnPropertyChanged("Address");
                }
            }
        }
    }
}
