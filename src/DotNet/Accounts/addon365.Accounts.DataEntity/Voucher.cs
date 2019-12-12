﻿using addon365.Common.DataEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Accounts.DataEntity
{
    [Table("Accounts.Vouchers")]
    public class Voucher : BaseEntityWithLogFields
    {
        public string Identifier { get; set; }
        public DateTime VoucherDate { get; set; }
        public Guid VoucherTypeId { get; set; }
        [ForeignKey("VoucherTypeId")]
        public virtual VoucherTypeMaster VoucherTypeMaster { get; set; }

        public ICollection<VoucherInfo> VoucherInfos { get; set; }
    }
}
