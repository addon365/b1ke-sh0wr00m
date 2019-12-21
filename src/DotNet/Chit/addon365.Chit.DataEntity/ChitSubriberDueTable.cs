
using addon365.Accounts.DataEntity;
using addon365.Common.DataEntity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Chit.DataEntity
{
    public class ChitSubriberDueTable : BaseEntityWithLogFields
    {
        public Guid ChitSubscriberKeyId { get; set; }
        [ForeignKey("ChitSubscriberKeyId")]
        public virtual ChitSubscriberTable ChitSubscriber { get; set; }
        public string DueNo { get; set; }
        public Guid VoucherKeyId { get; set; }
        [ForeignKey("VoucherKeyId")]
        public Voucher Voucher { get; set; }
        public Guid DueAmountKeyId { get; set; }
        [ForeignKey("DueAmountKeyId")]
        public VoucherInfo DueAmountInfo { get; set; }
    }
}
