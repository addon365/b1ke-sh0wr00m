using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using addon365.Database.Entity.Chit;
using addon365.Database.Entity.Crm;
using addon365.Domain.Entity.Chit.Reports;
using addon365.Database.Service.Chit;
using addon365.IService.Chit;
using Microsoft.Extensions.DependencyInjection;

namespace addon365.UI.ViewModel.Chit.Reports
{
    public class SubscriberReportViewModel : ViewModelBase
    {
        private ISubscribeService _subscribeService;
        private IList<SubscriberReportDomain> _reports;
        private ISchemeService _schemeService;
        private IEnumerable<ChitScheme> _chitSchemes;
        private ChitScheme _selectedScheme;
        private IList<Customer> _customers;
        private Customer _selectedCustomer;

        public SubscriberReportViewModel(Result onResult = null)
        {
            var Scope = Startup.Instance.provider.CreateScope();

            this._subscribeService = Scope.ServiceProvider.GetRequiredService<ISubscribeService>();
            //this._subscribeService = new addon365.WebClient.Service.WebService.Chit.SubsriberService();
           
            //this._schemService = new addon365.WebClient.Service.WebService.Chit.SchemeService();
            this._schemeService = Scope.ServiceProvider.GetRequiredService<ISchemeService>();
            WireCommands();
            FetchAllAsync();

        }

        public void WireCommands()
        {
            FetchCommand = new RelayCommand(FetchReport);
        }
        private void FetchAllAsync()
        {
            Message = "Initializing...";

            FetchReportAsync();
            FindAllSchemesAsync();
            FindAllCustomersAsync();
            
            
        }
        private void FetchReport()
        {
            FetchReportAsync();
        }
        private async void FetchReportAsync()
        {
            var Scope = Startup.Instance.provider.CreateScope();
           
            var TempService = Scope.ServiceProvider.GetRequiredService<ISubscribeService>();
            Guid customerId = Guid.Empty;
            Guid schemeId = Guid.Empty;
            if (SelectedCustomer != null)
                customerId = SelectedCustomer.Id;
            if (SelectedScheme != null)
                schemeId = SelectedScheme.Id;
            IsProgressBarVisible = true;
            Message = "Loading subscriptions...";
            Reports = await Task.Run(
                () => TempService.FetchReport(
                schemeId, customerId
                ));
            Message = "Done Loading subscriptions...";
            IsProgressBarVisible = false;
        }
        private async void FindAllSchemesAsync()
        {

           var Scope= Startup.Instance.provider.CreateScope();
           var TempService = Scope.ServiceProvider.GetRequiredService<ISchemeService>();
            IsProgressBarVisible = true;
            Message = "Loading scheme names...";
            var schemes = await Task.Run(() => TempService.FindAll());
            var defaultText = new ChitScheme()
            {
                Id = Guid.Empty,
                SchemaName = "All Schemes"
            };
            var list=new List<ChitScheme>(schemes.ToArray());
            list.Insert(0, defaultText);
            Schemes = list;
            SelectedScheme = list[0];
            Message = "Done Loading scheme names...";
            IsProgressBarVisible = false;
        }
        private async void FindAllCustomersAsync()
        {
            var Scope = Startup.Instance.provider.CreateScope();

            var TempService = Scope.ServiceProvider.GetRequiredService<ISubscribeService>();
            IsProgressBarVisible = true;
            Message = "Loading Customer names...";

            var customers = await Task.Run(
                () =>
            TempService.FindAllCustomers()
            );

            customers.Insert(0, new Customer()
            {
                Id=Guid.Empty,
                Contact = new Contact()
                {
                    FirstName = "All Customers"
                }
            });
            Customers = customers;
            SelectedCustomer = Customers[0];
            Message = "Done Loading Customer names...";
            IsProgressBarVisible = false;
        }

        public RelayCommand FetchCommand
        {
            get;
            private set;
        }
        public IList<SubscriberReportDomain> Reports
        {
            get
            {
                return _reports;
            }
            set
            {
                if (Reports != value)
                {
                    _reports = value;
                    OnPropertyChanged("Reports");
                }
            }
        }
        public IEnumerable<ChitScheme> Schemes
        {
            get
            {
                return _chitSchemes;
            }
            set
            {
                if (Schemes != value)
                {
                    _chitSchemes = value;
                    OnPropertyChanged("Schemes");

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
                    FetchCommand.IsEnabled = true;
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
                if (SelectedScheme != value)
                {
                    _selectedScheme = value;
                    OnPropertyChanged("SelectedScheme");
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
                    FetchCommand.IsEnabled = true;
                }
            }
        }
    }
}
