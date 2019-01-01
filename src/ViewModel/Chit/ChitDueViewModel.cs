using addon.BikeShowRoomService.WebService.Chit;
using Api.Database.Entity.Accounts;
using Api.Database.Entity.Chit;
using Api.Database.Entity.Crm;
using Api.Domain.Chit;
using Swc.Service.Base;
using System.Linq;
using Swc.Service.Chit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ViewModel.Chit
{
    public class ChitDueViewModel : ViewModelBaseEn<ChitSubriberDue>
    {
        private double _totalDue;
        private double _paidDue;
        private double _balanceAmount;
        private string _subscriptionId;
        ISubscribeService subscribeService;
        IChitDueService chitDueService;
        private List<ChitDueDomain> listChitDues;
        public ChitDueViewModel(Result onResult = null)
            : base(new ChitDueClientService(), onResult)
        {
            this.subscribeService = new SubsriberService();
            chitDueService = (IChitDueService)Service;
            
        }
        public override void InitModel()
        {
            base.InitModel();
            Model = new ChitSubriberDue();
            Model.ChitSubscriber = new ChitSubscriber();

            Model.ChitSubscriber.Customer = new Customer();
            Model.ChitSubscriber.Customer.Profile = new Contact();
            Model.VoucherInfo = new VoucherInfo();
            Model.VoucherInfo.Voucher = new Voucher();

            Model.VoucherInfo.Voucher.VoucherDate = new DateTime();
            Model.VoucherInfo.Voucher.VoucherType = "Credit";
        }
        public override void WireCommands()
        {
            base.WireCommands();
            FindSubscriber = new RelayCommand(FindSubscriberById);
        }
        public override bool Validate()
        {
            Model.ChitSubscriberId = Model.ChitSubscriber.Id;
            Model.ChitSubscriber.ChitSchema = null;
            Model.ChitSubscriber = null;
            Model.VoucherInfo.Voucher.VoucherDate = DateTime.Now;
            Model.DueNo = DateTime.Now.ToBinary().ToString();
            return true;
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
            var result = subscribeService.findBySubscriptionId(
                SubscriptionId);
            if (result == null)
            {
                Message = "Subscription Id Not Found";

                return;
            }
            Model.ChitSubscriber = result;
            Task.Run(() => FetchDues());
            
        }
        private void FetchDues()
        {
            ChitScheme chitScheme = Model.ChitSubscriber.ChitSchema;
            Guid id = Model.ChitSubscriber.Id;
            ChitDueList = ChitDueDomain.FromEntityModels(chitDueService.GetList(id));
            TotalDue = chitScheme.MonthlyAmount * chitScheme.TotalMonths;
            PaidDue = ChitDueList.Sum(s => s.Amount);
            BalanceAmount = TotalDue - PaidDue;
            Model.VoucherInfo.Amount = chitScheme.MonthlyAmount;
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
                    OnPropertyChanged("Model");
                    SaveCommand.IsEnabled = true;
                    Message = "";
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
        
    }
}
