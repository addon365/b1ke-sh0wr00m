using addon365.Database.Entity.Crm;
using addon365.Database.Service.Base;
using addon365.IService.Crm;
using System;
using System.Collections.Generic;
using System.Text;
using Threenine.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using addon365.Domain.Entity.Crm;

namespace addon365.Database.Service.Crm
{
    public class CampaignService : BaseService<Campaign>,
        ICampaignService
    {
        ApiContext CrmContext { get; set; }
        public CampaignService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            CrmContext = ((UnitOfWork<ApiContext>)unitOfWork).Context;
        }


        public override IList<Campaign> Save(IList<Campaign> collObj)
        {
            Campaign campaign = collObj.SingleOrDefault();

            var customerStatus =
                UnitOfWork.GetRepository<LeadStatusMaster>()
                .GetList(x => x.Name == "Customer")
                .Items.SingleOrDefault();
            Guid? find = Guid.Parse(campaign.Filter);

            var result = CrmContext.Leads
                .Where(x => x.Contact.ContactAddress.SubDistrictId == find)
                .ToArray();

            campaign.Infos = new List<CampaignInfo>(result.Length);

            for (int i = 0; i < result.Length; i++)
            {
                CampaignInfo campaignInfo =
                    new CampaignInfo();
                campaignInfo.Id = Guid.NewGuid();
                campaignInfo.IsInProgress = false;
                campaignInfo.LeadId = result[i].Id;
                campaign.Infos.Add(campaignInfo);
            }

            Repository.Add(campaign);
            UnitOfWork.SaveChanges();

            return collObj;
        }

        public List<CampaignViewModel> GetCampaigns()
        {
            return CrmContext.Campaigns
                .Include(x => x.Infos)
                .Select<Campaign, CampaignViewModel>(x =>
                     new CampaignViewModel
                     {
                         Id = x.Id,
                         Name = x.Name,
                         Description = x.Description,
                         Filter = CrmContext.SubDistricts.Where(y => y.Id == Guid.Parse(x.Filter)).SingleOrDefault().SubDistrictName,
                         Count = x.Infos.Count
                     }
                ).ToList();

        }


        public List<CampaignInfoViewModel> FindCampaignInfos(Guid campaignId)
        {
            var dbLeads = CrmContext.Leads;
            var dbCampaigns = CrmContext.Campaigns;
            var dbCampaignInfo = CrmContext.CampaignInfos;

            return dbCampaigns.Join<Campaign, CampaignInfo, Guid, CampaignInfoViewModel>(
                dbCampaignInfo,
                campaign => campaign.Id,
                campaignInfo => campaignInfo.CampaignId,
                (campaign, campaignInfo) => new CampaignInfoViewModel
                {
                    Id = campaignInfo.Id,
                    CampaignId = campaignId,
                    CompanyName = campaignInfo.Lead.Contact.BusinessName,
                    LeadId = campaignInfo.LeadId,
                    IsInProgress = campaignInfo.IsInProgress,
                    StatusName = "Open",
                }
                ).ToList();

        }

        public CampaignInfo FindCampaignInfo(Guid campaignInfoId)
        {
            var dbCampaignInfo = CrmContext.CampaignInfos;
            return dbCampaignInfo.Include(campaignInfo => campaignInfo.Lead)
                 .ThenInclude(c => c.Contact)
                 .ThenInclude(ct => ct.ContactAddress)
                 .Include(c => c.Lead)
                 .ThenInclude(c => c.Contact)
                 .ThenInclude(ct => ct.Proprietor)
                 .Include(c => c.Lead)
                 .ThenInclude(c => c.Contact)
                 .ThenInclude(ct => ct.ContactPerson)
                 .Include(c => c.Lead)
                 .ThenInclude(t => t.Source)
                 .Include(c => c.Lead)
                 .ThenInclude(t => t.History)

                 .ThenInclude(t => t.Status)
                 .Where(campaignInfo => campaignInfo.Id == campaignInfoId)
                 .SingleOrDefault();
        }
    }
}
