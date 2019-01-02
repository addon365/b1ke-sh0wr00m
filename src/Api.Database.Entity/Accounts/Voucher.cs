using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity.Accounts
{
    public class Voucher : BaseEntity
    {
        public string Identifier { get; set; }
        public DateTime VoucherDate { get; set; }
        public Guid VoucherTypeId { get; set; }
        [ForeignKey("VoucherTypeId")]
        public virtual VoucherTypeMaster VoucherTypeMaster { get; set; }

        public ICollection<VoucherInfo> VoucherInfos { get; set; }
    }
}
