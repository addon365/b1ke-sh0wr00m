using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity.Crm
{
    public class CampaignInfo:BaseEntity
    {
        public Guid CampaignId { get; set; }
        public Guid ContactId { get; set; }
        public Guid ModeId { get; set; }
        public Guid StatusId { get; set; }
        public string Description { get; set; }
    }
}
