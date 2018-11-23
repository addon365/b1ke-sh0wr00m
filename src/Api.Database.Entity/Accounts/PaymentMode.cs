using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity.Accounts
{
    public class PaymentMode:BaseEntity
    {
        public string Name { get; set; }
        public string ProgrammerId { get; set; }
    }
}
