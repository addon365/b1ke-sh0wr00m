using addon365.Domain.Entity.Chit;
using addon365.IService.Chit;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace addon365.UI.ViewModel.Chit
{
    public class FindSubscriptionViewModel : ViewModelBase
    {
        IChitDueService chitDueService;
        private string _mobileSearchText;
        private string _nameSearchText;
        
        private IList<CustomerDueDomain> _dueDomains;
        public FindSubscriptionViewModel(Result onResult = null)
        {
            var Scope = Startup.Instance.provider.CreateScope();

            chitDueService = Scope.ServiceProvider.GetRequiredService<IChitDueService>();
            //chitDueService = new ChitDueClientService();
            WireCommands();
        }

        public void WireCommands()
        {
            FindSubscriber = new RelayCommand(FindSubscriptions);
        }
        public RelayCommand FindSubscriber
        {
            get;
            private set;
        }
        private void FindSubscriptions()
        {
            if (!string.IsNullOrEmpty(MobileSearchText))
                ChitDueList = chitDueService.FindByMobile(MobileSearchText);
            else if (!string.IsNullOrEmpty(NameSearchText))
                ChitDueList = chitDueService.FindByCustomerName(NameSearchText);
            else
                Message = "Enter mobile Number or messsage";

            if (ChitDueList.Count == 0)
                Message = "Cannot find given text";

        }
        public IList<CustomerDueDomain> ChitDueList
        {
            get
            {
                return _dueDomains;
            }
            set
            {
                if (ChitDueList != value)
                {
                    _dueDomains = value;
                    OnPropertyChanged("ChitDueList");
                }
            }
        }
        public string MobileSearchText
        {
            get
            {
                return _mobileSearchText;
            }
            set
            {
                if (MobileSearchText != value)
                {
                    _mobileSearchText = value;
                    OnPropertyChanged("MobileSearchText");

                    FindSubscriber.IsEnabled = !string.IsNullOrEmpty(value);
                }
            }
        }
        public string NameSearchText
        {
            get
            {
                return _nameSearchText;
            }
            set
            {
                if (NameSearchText != value)
                {
                    _nameSearchText = value;
                    OnPropertyChanged("NameSearchText");

                    FindSubscriber.IsEnabled = !string.IsNullOrEmpty(value);
                }
            }
        }
    }
}
