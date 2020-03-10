using addon365.Common.DataEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Accounts.DataEntity
{
    [Table("Accounts.Vouchers")]
    public class VoucherTable : BaseEntityWithLogFields
    {
        public string AccessId { get; set; }
        public DateTime VoucherDate { get; set; }
        public Guid? VoucherTypeKeyId { get; set; }
        [ForeignKey("VoucherTypeKeyId")]
        public virtual VoucherTypeTable VoucherType { get; set; }

        public ICollection<VoucherInfoTable> VoucherInfos { get; set; }
    }
}
