using addon365.Common.DataEntity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Accounts.DataEntity
{
    [Table("Accounts.VoucherInfos")]
    public class VoucherInfoTable : BaseEntityWithLogFields
    {
        public Guid VoucherKeyId { get; set; }
        [ForeignKey("VoucherKeyId")]
        public VoucherTable Voucher { get; set; }

        public Guid? AccountBookKeyId { get; set; }
        [ForeignKey("AccountBookKeyId")]
        public AccountBookTable AccountBook { get; set; }

        public Decimal Amount { get; set; }
        public bool IsCredit { get; set; }
        public string FieldInfo { get; set; }
    }
}
