using Api.Database.Entity.Crm;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Swc.Service.Crm
{
    public interface IFollowUpService
    {
        IEnumerable<FollowUpStatus> GetFollowUpStatuses();
        IEnumerable<FollowUpMode> GetFollowUpModes();
        IEnumerable<CampaignInfo> GetCampaingInfos(string contactId);
        Contact GetContact(string contactId);
        Task<CampaignInfo> InsertAsync(CampaignInfo campaignInfo);
        FollowUpStatus GetFollowUpStatus(Guid guid);
        FollowUpMode GetFollowUpMode(Guid guid);
    }
}
