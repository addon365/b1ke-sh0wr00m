
using addon365.Accounts.DataEntity;
using addon365.Common.DataEntity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Chit.DataEntity
{
    public class ChitSubriberDue : BaseEntityWithLogFields
    {
        public Guid ChitSubscriberId { get; set; }
        [ForeignKey("ChitSubscriberId")]
        public virtual ChitSubscriber ChitSubscriber { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string DueNo { get; set; }
        public Voucher Voucher { get; set; }
    }
}
