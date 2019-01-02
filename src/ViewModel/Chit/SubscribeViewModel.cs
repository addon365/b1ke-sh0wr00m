using addon.BikeShowRoomService.WebService.Chit;
using Api.Database.Entity.Chit;
using Api.Database.Entity.Crm;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Api.Database.Entity.Accounts;
using System;

namespace ViewModel.Chit
{
    public class SubscribeViewModel : ViewModelBaseEn<ChitSubriberDue>
    {
        public IList<ChitScheme> _schemes;
        private ChitScheme _selectedScheme;
        private double _schemeAmount;
        private Swc.Service.Chit.ISchemeService _schemeService;
        public SubscribeViewModel()
            : base(new ChitDueClientService())
        {
            FetchSchemesAsync();

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
                    Model.ChitSubscriber.ChitSchema = _selectedScheme;
                    Model.VoucherInfo.Amount = _selectedScheme.MonthlyAmount;
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
            string mobileNumber = Model.ChitSubscriber.Customer.Profile.MobileNumber;
            if (mobileNumber == null || (mobileNumber != null && mobileNumber.Length < 10))
            {
                Message = "Mobile Number not valid";
                return false;
            }
            double amount = Model.VoucherInfo.Amount;
            if (amount == 0 || amount < 0)
            {
                Message = "Amount should be greater than zero";
                return false;
            }
            ChitScheme chitScheme = Model.ChitSubscriber.ChitSchema;
            if (chitScheme == null)
            {
                Message = "Choose a Schema.";
                return false;
            }
            Model.ChitSubscriber.ChitSchemeId = Model.ChitSubscriber.ChitSchema.Id;
            Model.ChitSubscriber.ChitSchema = null;
            Guid id = Model.ChitSubscriber.ChitSchemeId;
            if (id == null || id == Guid.Empty)
            {
                Message = "Choose a Schema.";
                return false;
            }
            string name = Model.ChitSubscriber.Customer.Profile.Name;
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
