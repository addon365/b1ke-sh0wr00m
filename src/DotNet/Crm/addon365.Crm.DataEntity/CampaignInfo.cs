using addon365.Common.DataEntity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Crm.DataEntity
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
