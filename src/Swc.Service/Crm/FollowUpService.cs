using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Database.Entity.Crm;
using Threenine.Data;

namespace Swc.Service.Crm
{
    public class FollowUpService : IFollowUpService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FollowUpService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Contact GetContact(string contactId)
        {
            IEnumerable<Contact> contacts = _unitOfWork.GetRepository<Contact>()
                .GetList().Items;

            foreach (Contact contact in contacts)
            {
                if (contact.Id.ToString().CompareTo(contactId) == 0)
                    return contact;
            }
            return null;

        }
        public IEnumerable<CampaignInfo> GetCampaingInfos(string contactId)
        {
            IEnumerable<CampaignInfo> campaignInfos = _unitOfWork.GetRepository<CampaignInfo>()
                .GetList().Items;
            IList<CampaignInfo> campaignInfoList = new List<CampaignInfo>();
            foreach (CampaignInfo campaignInfo in campaignInfos)
            {
                if (campaignInfo.ContactId.ToString().CompareTo(contactId) == 0)
                    campaignInfoList.Add(campaignInfo);
            }
            return campaignInfoList;
        }

        public IEnumerable<FollowUpStatus> GetFollowUpStatuses()
        {
            return _unitOfWork.GetRepository<FollowUpStatus>().GetList().Items;
        }
        public IEnumerable<FollowUpMode> GetFollowUpModes()
        {
            return _unitOfWork.GetRepository<FollowUpMode>().GetList().Items;
        }

        public Task<string> InsertAsync(CampaignInfo campaignInfo)
        {
            try
            {
                _unitOfWork.GetRepository<CampaignInfo>().Add(campaignInfo);
                _unitOfWork.SaveChanges();
            }
            catch(Exception exception)
            {
                return Task.FromResult<string>(exception.Message);
            }
            return null;
        }

        public FollowUpStatus GetFollowUpStatus(Guid guid)
        {
            throw new NotImplementedException();
        }

        public FollowUpMode GetFollowUpMode(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
