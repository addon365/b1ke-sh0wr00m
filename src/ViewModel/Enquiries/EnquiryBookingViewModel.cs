﻿using Api.Database.Entity.Crm;
using Swc.Service.Crm;
using System;
using System.Collections.Generic;

namespace ViewModel.Enquiries
{
    public class EnquiryBookingViewModel : ViewModelBase
    {
        
        private IEnumerable<FollowUpStatus> _followUpStatuses;
        private IEnumerable<CampaignInfo> _campaignInfos;
        private IEnumerable<FollowUpMode> _followUpModes;
        private CampaignInfo _campaignInfo;
        private readonly IFollowUpService _repository;
        

        public EnquiryBookingViewModel(Api.Domain.Enquiries.Enquiries enq)
        {
            
            _repository = new addon.BikeShowRoomService.WebService.FollowUpService();
            _followUpStatuses = _repository.GetFollowUpStatuses();
            _followUpModes = _repository.GetFollowUpModes();
            
           
            string contactId = enq.Contact.Id.ToString();
            Contact contact = _repository.GetContact(contactId);

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
            string message = await _repository.InsertAsync(_campaignInfo);
            if (!string.IsNullOrEmpty(message.Trim()))
            {
                Message = message;
                IsProgressBarVisible = false;
            }
            else
            {
                OnResult(true, "Successfully Updated Follow Up.");
                this.CurrentInfo = new CampaignInfo
                {
                    ContactId = contactId
                };

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