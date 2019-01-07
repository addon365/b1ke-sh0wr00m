using addon.BikeShowRoomService.WebService.Chit;
using Api.Database.Entity.Chit;
using Swc.Service.Chit;

namespace ViewModel.Chit
{
    public class FindSubscriptionViewModel : ViewModelBaseEn<ChitSubriberDue>
    {
        IChitDueService chitDueService;
        private string _searchText;
        public FindSubscriptionViewModel(Result onResult = null)
            : base(new ChitDueClientService(), onResult)
        {
            chitDueService = (IChitDueService)Service;
        }

        public override void WireCommands()
        {
            base.WireCommands();
            FindSubscriber = new RelayCommand(FindSubscriptions);
        }
        public RelayCommand FindSubscriber
        {
            get;
            private set;
        }
        private void FindSubscriptions()
        {
        }
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                if (SearchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged("SearchText");

                    FindSubscriber.IsEnabled = !string.IsNullOrEmpty(value);
                }
            }
        }
    }
}
