using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Domain.Entity.Crm
{
    public class CampaignInfoViewModel
    {
        public Guid Id { get; set; }
        public Guid CampaignId { get; set; }

        public String CompanyName { get; set; }
        public Guid LeadId { get; set; }

        public String StatusName { get; set; }
        public bool IsInProgress { get;set; }
    }
}
