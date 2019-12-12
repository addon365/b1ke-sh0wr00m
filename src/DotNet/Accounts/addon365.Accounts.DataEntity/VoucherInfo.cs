using addon365.Common.DataEntity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Accounts.DataEntity
{
    [Table("Accounts.VoucherInfos")]
    public class VoucherInfo : BaseEntityWithLogFields
    {
        public Guid VoucherId { get; set; }

        public Guid bookId { get; set; }
        [ForeignKey("bookId")]
        public AccountBook AccountBook { get; set; }

        public double Amount { get; set; }
        public bool IsCredit { get; set; }
        public string FieldInfo { get; set; }
    }
}
