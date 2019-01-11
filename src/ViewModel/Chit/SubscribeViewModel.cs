using addon.BikeShowRoomService.WebService.Chit;
using Api.Database.Entity.Chit;
using Api.Database.Entity.Crm;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Api.Database.Entity.Accounts;
using System;
using Api.Domain.Chit;

namespace ViewModel.Chit
{
    public class SubscribeViewModel : ViewModelBaseEn<ChitSubriberDue>
    {
        public ChitSubscribeDomain _chitSubscribeDomain;
        public IList<ChitScheme> _schemes;
        private ChitScheme _selectedScheme;
        private double _schemeAmount;
        private Swc.Service.Chit.ISchemeService _schemeService;
        public SubscribeViewModel()
            : base(new ChitDueClientService())
        {
            FetchSchemesAsync();
            ChitSubscribe = new ChitSubscribeDomain();
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
                }
            }
        }

        public override void InitModel()
        {
            base.InitModel();
            Model = new ChitSubriberDue();
            Model.ChitSubscriber = new ChitSubscriber();

            Model.ChitSubscriber.Customer = new Customer();
            Model.ChitSubscriber.Customer.Profile = new Contact();
            Model.VoucherInfo = new VoucherInfo();
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
                _schemeService = new SchemeService();
            }
            Task task = new Task(
                () => Schemes = _schemeService.FindAll().ToList());
            task.Start();
        }

        public override bool Validate()
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
        public override void SayMessage(bool isSuccess, string message)
        {
            if (!isSuccess)
                base.SayMessage(isSuccess, message);
            else
            {
                Message = "Successfully Saved and your Subscription id is " +
                    Model.ChitSubscriber.SubscribeId;
                InitModel();
            }
        }
    }
}
