using addon365.WebClient.Service.WebService.Chit;
using addon365.Database.Service.Chit;
using addon365.IService.Chit;

namespace addon365.UI.ViewModel.Chit
{
    public class CloseSubscriptionViewModel : ViewModelBase
    {
        ISubscribeService subscribeService;
        private string _subscriptionId;
        private double _amount;
        public CloseSubscriptionViewModel(Result onResult = null)
        {
            this.subscribeService = new SubsriberService();
            WireCommands();
            IsProgressBarVisible = false;
        }
        public void WireCommands()
        {
            SaveCommand = new RelayCommand(Save);
        }
        public RelayCommand SaveCommand
        {
            get;
            private set;
        }
        public string SubscriptionId
        {
            get
            {
                return _subscriptionId;
            }
            set
            {
                if (SubscriptionId != value)
                {
                    _subscriptionId = value;
                    OnPropertyChanged("SubscriptionId");
                    SaveCommand.IsEnabled = true;
                }
            }
        }

        public double Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (Amount != value)
                {
                    _amount = value;
                    OnPropertyChanged("Amount");
                }
            }
        }
        public void Save()
        {
            SaveCommand.IsEnabled = false;
            IsProgressBarVisible = true;
            if (!IsValid())
                return;
            string errorMessage=subscribeService.CloseSubscription(SubscriptionId, Amount);
            if (errorMessage == null)
            {
                Amount = 0;
                SubscriptionId = "";
                SaveCommand.IsEnabled = false;
                Message = "Successfully closed subscription";
            }
            else
            {
                Message = errorMessage;
            }
            IsProgressBarVisible = false;
        }
        public bool IsValid()
        {
            if (string.IsNullOrEmpty(SubscriptionId))
            {
                Message = "Subscription Id should not be empty";
                return false;
            }
            if (Amount == 0)
            {
                Message = "Amount should not be empty";
                return false;
            }
            return true;
        }
    }
}
