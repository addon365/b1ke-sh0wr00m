using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Crm
{
    public class CampaignInfo : BaseEntityWithLogFields
    {

        public Guid LeadId { get; set; }
        [ForeignKey("LeadId")]
        public Lead Lead { get; set; }

        public bool IsInProgress { get; set; }

        public Guid CampaignId { get; set; }

    }
}
