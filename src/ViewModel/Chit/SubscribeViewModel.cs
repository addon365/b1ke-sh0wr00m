using addon.BikeShowRoomService.WebService.Chit;
using Api.Database.Entity.Chit;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Api.Domain.Chit;
using Swc.Service.Chit;
using SchemeClientService = addon.BikeShowRoomService.WebService.Chit.SchemeService;

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
        public SubscribeViewModel()
        {
            WireCommands();
            FetchSchemesAsync();
            ChitSubscribe = new ChitSubscribeDomain();
            _dueService = new ChitDueClientService();
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
            if (!Validate()) return;
            IsProgressBarVisible = true;
            try
            {
                var result=_dueService.Save(ChitSubscribe);
                Message = "Saved Successfullly and id is "+result.ChitSubscriber.SubscribeId;
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
    }
}
