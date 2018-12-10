using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity.Accounts
{
    public class Voucher:BaseEntity
    {
        public string Identifier { get; set; }
        public DateTime VoucherDate { get; set; }
    }
}
