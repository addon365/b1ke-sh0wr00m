using addon365.Database.Entity.Crm;
using addon365.Database.Service.Crm;
using System;
using System.Collections.Generic;

namespace addon365.UI.ViewModel.Crm
{
    public class FollowUpViewModel : ViewModelBase
    {
        
        private IEnumerable<FollowUpStatus> _followUpStatuses;
        private IEnumerable<CampaignInfo> _campaignInfos;
        private IEnumerable<FollowUpMode> _followUpModes;
        private CampaignInfo _campaignInfo;
        private readonly IFollowUpService _repository;
        

        public FollowUpViewModel(object contactObj = null, Result onResult = null)
        {
            this.OnResult = onResult;
            _repository = new addon365.WebClient.Service.WebService.FollowUpService();
            _followUpStatuses = _repository.GetFollowUpStatuses();
            _followUpModes = _repository.GetFollowUpModes();
            
            Contact ob =(Contact) contactObj;
            string contactId = ob.Id.ToString();
            Contact contact = _repository.GetContact(ob.Id.ToString());

            WireCommands();



            IList<CampaignInfo> campaignInfos = new List<CampaignInfo>();
            foreach (CampaignInfo campaignInfo in _repository.GetCampaingInfos(contactId))
            {
                campaignInfo.Status = _repository.GetFollowUpStatus(campaignInfo.StatusId);
                campaignInfo.Mode = _repository.GetFollowUpMode(campaignInfo.ModeId);
                campaignInfos.Add(campaignInfo);
            }
            CampaignInfos = campaignInfos;


            CurrentInfo = new CampaignInfo
            {
                ContactId = contact.Id,
                Contact = contact
            };
            foreach (FollowUpMode followUpMode in _followUpModes)
            {
                if (followUpMode.Name.Equals("Call"))
                {
                    CurrentInfo.Mode = followUpMode;
                    CurrentInfo.ModeId = followUpMode.Id;
                }
            }
        }
        private void WireCommands()
        {
            InsertCampaignInfoCommand = new RelayCommand(InsertCampainInfo);
        }
        public RelayCommand InsertCampaignInfoCommand
        {
            get;
            private set;
        }
        public CampaignInfo CurrentInfo
        {
            get
            {
                return _campaignInfo;
            }
            set
            {
                if (CurrentInfo != value)
                {
                    _campaignInfo = value;
                    OnPropertyChanged("CurrentInfo");
                    InsertCampaignInfoCommand.IsEnabled = true;

                }
            }
        }

        public IEnumerable<CampaignInfo> CampaignInfos
        {
            get { return _campaignInfos; }
            set { _campaignInfos = value; }
        }
        public IEnumerable<FollowUpStatus> FollowUpStatuses
        {
            get
            {
                return _followUpStatuses;
            }
            set
            {
                if (FollowUpStatuses != value)
                {
                    _followUpStatuses = value;
                    OnPropertyChanged("FollowUpStatuses");
                }
            }
        }
        private bool IsValid()
        {
            if (CurrentInfo.Status == null)
            {
                Message = "Status field is Manditory.";
                return false;
            }
            if (CurrentInfo.Comments.Length <= 3)
            {
                Message = "Comments fields must contain meaningfull message.";
                return false;
            }
            return true;

        }
        public async void InsertCampainInfo()
        {
            if (!IsValid()) return;
            InsertCampaignInfoCommand.IsEnabled = false;
            IsProgressBarVisible = true;
            _campaignInfo.Id = Guid.NewGuid();
            Guid contactId = this.CurrentInfo.ContactId;
            _campaignInfo.StatusId = _campaignInfo.Status.Id;
            _campaignInfo.Mode = null;
            _campaignInfo.Status = null;
            _campaignInfo.Contact = null;
            try
            {
                _repository.Insert(_campaignInfo);
                OnResult(true, "Successfully Updated Follow Up.");
                this.CurrentInfo = new CampaignInfo
                {
                    ContactId = contactId
                };
            }
            catch(Exception ex)
            {
                Message = ex.Message;
                IsProgressBarVisible = false;
            }
            InsertCampaignInfoCommand.IsEnabled = true;
        }
        public Result OnResult
        {
            get;
            set;
        }
    }
}
