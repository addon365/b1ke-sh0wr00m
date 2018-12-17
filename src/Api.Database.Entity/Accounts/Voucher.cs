using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity.Accounts
{
    public class Voucher:BaseEntity
    {
        public DateTime VoucherDate { get; set; }
        public string VoucherType { get; set; }
    }
}
