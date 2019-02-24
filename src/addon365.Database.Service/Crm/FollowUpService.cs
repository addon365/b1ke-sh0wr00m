using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using addon365.Database.Entity.Crm;
using Threenine.Data;

namespace addon365.Database.Service.Crm
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

        public CampaignInfo Insert(CampaignInfo campaignInfo)
        {
            _unitOfWork.GetRepository<CampaignInfo>().Add(campaignInfo);
            _unitOfWork.SaveChanges();
            return campaignInfo;
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
