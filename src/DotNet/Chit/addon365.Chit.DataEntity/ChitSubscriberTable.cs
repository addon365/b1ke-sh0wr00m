using addon365.Common.DataEntity;
using addon365.Crm.DataEntity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Chit.DataEntity
{
    public class ChitSubscriberTable : BaseEntityWithLogFields
    {
        public string SubscribeAccessId { get; set; }
        public Guid ChitGroupKeyId { get; set; }
        [ForeignKey("ChitGroupKeyId")]
        public virtual ChitGroupTable ChitSchema { get; set; }
        [ForeignKey("CustomerKeyId")]
        public virtual CustomerTable Customer { get; set; }
        public Guid CustomerKeyId { get; set; }
        public DateTime JoinedDate { get; set; }
        public Guid ClosedVoucherId { get; set; }
    }
}
