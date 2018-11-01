using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity.Accounts
{
    public class VoucherInfo:BaseEntity
    {
        public Guid VoucherId { get; set; }
        public double Amount { get; set; }
        public bool IsCredit { get; set; }
        public int FieldId { get; set;  }
    }
}
