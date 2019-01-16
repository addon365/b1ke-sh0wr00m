using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity.Crm
{
    public class CampaignInfo : BaseEntityWithLogFields
    {
        public Guid CampaignId { get; set; }
        public Guid ContactId { get; set; }
        [ForeignKey("ContactId")] public virtual Contact Contact { get; set; }
        public Guid ModeId { get; set; }
        [ForeignKey("ModeId")] public virtual FollowUpMode Mode { get; set; }
        public Guid StatusId { get; set; }
        [ForeignKey("StatusId")] public virtual FollowUpStatus Status { get; set; }
        public string Comments { get; set; }
    }
}
