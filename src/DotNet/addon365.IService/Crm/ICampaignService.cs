using addon365.Database.Entity.Crm;
using addon365.Domain.Entity.Crm;
using addon365.IService.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.IService.Crm
{
    public interface ICampaignService : IBaseService<Campaign>
    {
        List<CampaignViewModel> GetCampaigns();
        List<CampaignInfoViewModel> FindCampaignInfos(Guid campaignId);

        CampaignInfo FindCampaignInfo(Guid campaignInfoId);
    }
}
