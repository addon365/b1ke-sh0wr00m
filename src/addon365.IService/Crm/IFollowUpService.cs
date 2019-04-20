using addon365.Database.Entity.Crm;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace addon365.IService.Crm
{
    public interface IFollowUpService
    {
        IEnumerable<FollowUpStatus> GetFollowUpStatuses();
        IEnumerable<FollowUpMode> GetFollowUpModes();
        IEnumerable<CampaignInfo> GetCampaingInfos(string contactId);
        Contact GetContact(string contactId);
        CampaignInfo Insert(CampaignInfo campaignInfo);
        FollowUpStatus GetFollowUpStatus(Guid guid);
        FollowUpMode GetFollowUpMode(Guid guid);
    }
}
