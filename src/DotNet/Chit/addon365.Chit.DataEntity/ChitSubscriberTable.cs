using addon365.Common.DataEntity;
using addon365.Crm.DataEntity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Chit.DataEntity
{
    [Table("Chit.ChitSubscribers")]
    public class ChitSubscriberTable : BaseEntityWithLogFields
    {
        public string AccessId { get; set; }
        public Guid ChitGroupKeyId { get; set; }
        [ForeignKey("ChitGroupKeyId")]
        public virtual ChitGroupTable ChitGroup { get; set; }
        [ForeignKey("CustomerKeyId")]
        public virtual CustomerTable Customer { get; set; }
        public Guid CustomerKeyId { get; set; }
        public Guid? AgentKeyId { get; set; }
        public virtual AgentTable Agent { get; set; }
        public DateTime JoinedDate { get; set; }
        public Guid ClosedVoucherId { get; set; }
    }
}
