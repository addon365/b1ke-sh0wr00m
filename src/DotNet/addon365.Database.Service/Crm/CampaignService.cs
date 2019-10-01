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
using addon365.Database.Entity.Crm.Address;

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

            //currently we have support to parse multiple subDistrictIds with comma separator.
            string[] strSubDistrictIds = campaign.Filter.Split(',');
            campaign.Infos = new List<CampaignInfo>();
            for (int si = 0; si < strSubDistrictIds.Length; si++)
            {
                Guid? find = Guid.Parse(strSubDistrictIds[si]);

                var result = CrmContext.Leads
                    .Where(x => x.Contact.ContactAddress.SubDistrictId == find)
                    .ToArray();


                for (int i = 0; i < result.Length; i++)
                {
                    CampaignInfo campaignInfo =
                        new CampaignInfo();
                    campaignInfo.Id = Guid.NewGuid();
                    campaignInfo.IsInProgress = false;
                    campaignInfo.LeadId = result[i].Id;
                    campaign.Infos.Add(campaignInfo);
                }
            }
            Repository.Add(campaign);
            UnitOfWork.SaveChanges();

            return collObj;
        }

        public List<CampaignViewModel> GetCampaigns()
        {

            var subDistricts = CrmContext.SubDistricts.ToList();
            return CrmContext.Campaigns
                .Include(x => x.Infos)
                .Select<Campaign, CampaignViewModel>(x =>
                     new CampaignViewModel
                     {
                         Id = x.Id,
                         Name = x.Name,
                         Description = x.Description,
                         Filter = GetFilterNames(subDistricts, x.Filter),
                         Count = x.Infos.Count
                     }
                ).ToList();

        }

        private string GetFilterNames(List<SubDistrictMaster> subDistrictMasters, string filter)
        {
            string[] strFilters = filter.Split(',');
            string strFilter = subDistrictMasters.Where(y => y.Id == Guid.Parse(strFilters[0])).SingleOrDefault().SubDistrictName;
            for (int i = 1; i < strFilters.Length; i++)
            {
                strFilter += "," + subDistrictMasters.Where(y => y.Id == Guid.Parse(strFilters[i])).SingleOrDefault().SubDistrictName;
            }

            return strFilter;
        }

        public List<CampaignInfoViewModel> FindCampaignInfos(Guid campaignId)
        {
            var dbLeads = CrmContext.Leads;
            var dbCampaigns = CrmContext.Campaigns;
            var dbCampaignInfo = CrmContext.CampaignInfos;

            return dbCampaigns
                .Where(campaign => campaign.Id == campaignId)
                .Join<Campaign, CampaignInfo, Guid, CampaignInfoViewModel>(
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
        public override Campaign Update(Guid id, Campaign campaign)
        {

            Campaign foundCampaign = CrmContext.Campaigns
                .Include(c => c.Infos)
                .Single(c => c.Id == campaign.Id);

            foundCampaign.Infos.Clear();
            foundCampaign.Name = campaign.Name;
            foundCampaign.Description = campaign.Description;
            foundCampaign.Filter = campaign.Filter;
            var customerStatus =
                UnitOfWork.GetRepository<LeadStatusMaster>()
                .GetList(x => x.Name == "Customer")
                .Items.SingleOrDefault();

            //currently we have support to parse multiple subDistrictIds with comma separator.
            string[] strSubDistrictIds = campaign.Filter.Split(',');

            for (int si = 0; si < strSubDistrictIds.Length; si++)
            {
                Guid? find = Guid.Parse(strSubDistrictIds[si]);

                var result = CrmContext.Leads
                    .Where(x => x.Contact.ContactAddress.SubDistrictId == find)
                    .ToArray();


                for (int i = 0; i < result.Length; i++)
                {
                    Lead lead = result[i];

                    CampaignInfo campaignInfo =
                        new CampaignInfo();
                    campaignInfo.Id = Guid.NewGuid();
                    campaignInfo.IsInProgress = false;
                    campaignInfo.LeadId = result[i].Id;
                    foundCampaign.Infos.Add(campaignInfo);
                }
            }

            CrmContext.SaveChanges();

            return foundCampaign;
        }
    }


}
