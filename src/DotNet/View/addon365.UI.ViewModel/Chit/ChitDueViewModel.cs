
using addon365.Database.Entity.Chit;
using addon365.Domain.Entity.Chit;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using addon365.IService.Chit;

namespace addon365.UI.ViewModel.Chit
{
    public class ChitDueViewModel : ViewModelBase
    {
        private double _totalDue;
        private double _paidDue;
        private double _balanceAmount;
        private string _subscriptionId;
        ISubscribeService subscribeService;
        IChitDueService chitDueService;
        private List<ChitDueDomain> listChitDues;
        public ChitSubscribeDomain _chitSubscribeDomain;
        private ChitSubscriber selectedChitSubscriber;
        public ChitDueViewModel(Result onResult = null)
        {
            try
            {

                subscribeService = (ISubscribeService)addon365.UI.ViewModel.Startup.Instance.provider.GetService(typeof(ISubscribeService));
                chitDueService = (IChitDueService)addon365.UI.ViewModel.Startup.Instance.provider.GetService(typeof(IChitDueService));
                WireCommands();
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
            }
        }

        public void WireCommands()
        {
            FindSubscriber = new RelayCommand(FindSubscriberById);
            SaveCommand = new RelayCommand(Save);
        }

        public void Save()
        {
            if (!Validate())
                return;

            var result = chitDueService.Save(SubscribeDomain);
            if (result == null)
            {
                Message = "Something went wrong";
            }
            else
            {

                SayMessage(true, "Successfully saved");
            }



        }
        public bool Validate()
        {
            if (BalanceAmount == 0)
            {
                Message = "Either All Dues are paid or subscription id not found.";
                return false;
            }

            return true;
        }
        public RelayCommand SaveCommand
        {
            get;
            private set;
        }
        public RelayCommand FindSubscriber
        {
            get;
            private set;
        }

        private void FindSubscriberById()
        {
            IsProgressBarVisible = true;
            FindSubscriber.IsEnabled = false;
            var result = subscribeService.FindBySubscriptionId(
                SubscriptionId);
            if (result == null)
            {
                Message = "Subscription Id Not Found";
                SubscribeDomain.Amount = 0;
                return;
            }
            SelectedSubscription = result;
            Task.Run(() => FetchDues());

        }
        private void FetchDues()
        {

            ChitScheme chitScheme = selectedChitSubscriber.ChitSchema;
            Guid id = selectedChitSubscriber.Id;
            ChitDueList = ChitDueDomain.FromEntityModels(chitDueService.GetList(id)); ;
            TotalDue = chitScheme.MonthlyAmount * chitScheme.TotalMonths;
            PaidDue = ChitDueList.Sum(s => s.Amount);
            BalanceAmount = TotalDue - PaidDue;
            SubscribeDomain = new ChitSubscribeDomain()
            {
                Address = selectedChitSubscriber.Customer.Contact.Address,
                CustomerName = selectedChitSubscriber.Customer.Contact.FirstName,
                MobileNumber = selectedChitSubscriber.Customer.Contact.MobileNumber,
                ChitSchemeId = selectedChitSubscriber.ChitSchemeId,
                SubscribeId = selectedChitSubscriber.Id

            };

            if (BalanceAmount != 0)
                SubscribeDomain.Amount = chitScheme.MonthlyAmount;
            IsProgressBarVisible = false;

        }
        public List<ChitDueDomain> ChitDueList
        {
            get
            {
                return listChitDues;
            }
            set
            {
                if (listChitDues != value)
                {
                    listChitDues = value;
                    OnPropertyChanged("ChitDueList");
                    Message = "";
                }
            }
        }
        public ChitSubscriber SelectedSubscription
        {
            get
            {
                return selectedChitSubscriber;
            }
            set
            {
                if (selectedChitSubscriber != value)
                {
                    selectedChitSubscriber = value;
                    OnPropertyChanged("SelectedSubscription");

                }
            }
        }
        public ChitSubscribeDomain SubscribeDomain
        {
            get
            {
                return _chitSubscribeDomain;
            }
            set
            {
                if (_chitSubscribeDomain != value)
                {
                    _chitSubscribeDomain = value;
                    OnPropertyChanged("SubscribeDomain");
                }
            }
        }
        public string SubscriptionId
        {
            get
            {
                return _subscriptionId;
            }
            set
            {
                if (_subscriptionId != value)
                {
                    _subscriptionId = value;
                    OnPropertyChanged("SubscriptionId");
                    FindSubscriber.IsEnabled = true;
                    SaveCommand.IsEnabled = true;
                }
            }
        }
        public double TotalDue
        {
            get
            {
                return _totalDue;
            }
            set
            {
                if (TotalDue != value)
                {
                    OnPropertyChanged("TotalDue");
                    _totalDue = value;
                }

            }
        }
        public double PaidDue
        {
            get
            {
                return _paidDue;
            }
            set
            {
                if (_paidDue != value)
                {
                    _paidDue = value;
                    OnPropertyChanged("PaidDue");
                }
            }
        }
        public double BalanceAmount
        {
            get
            {
                return _balanceAmount;
            }
            set
            {
                if (_balanceAmount != value)
                {
                    _balanceAmount = value;
                    OnPropertyChanged("BalanceAmount");
                }
            }
        }
        public void SayMessage(bool isSuccess, string message)
        {
            Message = message;
            if (isSuccess)
            {

                SubscribeDomain = new ChitSubscribeDomain();
                TotalDue = 0;
                PaidDue = 0;
                BalanceAmount = 0;
                ChitDueList = new List<ChitDueDomain>();
                SubscriptionId = "";
                FindSubscriber.IsEnabled = true;
                SubscribeDomain = new ChitSubscribeDomain();
                SelectedSubscription = new ChitSubscriber();
            }
        }

    }
}
