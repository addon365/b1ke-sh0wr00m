using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Database.Entity.Accounts
{
    public class VoucherInfo:BaseEntityWithLogFields
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
