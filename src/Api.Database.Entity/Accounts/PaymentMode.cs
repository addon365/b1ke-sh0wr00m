using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Database.Entity.Accounts
{
    public class PaymentMode:BaseEntityWithLogFields
    {
        public string Name { get; set; }
        public string ProgrammerId { get; set; }
    }
}
