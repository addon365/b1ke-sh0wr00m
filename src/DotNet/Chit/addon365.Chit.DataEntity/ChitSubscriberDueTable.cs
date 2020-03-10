
using addon365.Accounts.DataEntity;
using addon365.Common.DataEntity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Chit.DataEntity
{
    [Table("Chit.ChitSubscriberDues")]
    public class ChitSubscriberDueTable : BaseEntityWithLogFields
    {
        public string AccessId { get; set; }
        public Guid ChitSubscriberKeyId { get; set; }
        [ForeignKey("ChitSubscriberKeyId")]
        public virtual ChitSubscriberTable ChitSubscriber { get; set; }
        public int DueNo { get; set; }
        public Guid DueAmountInfoKeyId { get; set; }
        [ForeignKey("DueAmountInfoKeyId")]
        public VoucherInfoTable DueAmountInfo { get; set; }
    }
}
