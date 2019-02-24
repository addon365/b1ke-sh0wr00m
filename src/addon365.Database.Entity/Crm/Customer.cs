using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace addon365.Database.Entity.Crm
{
    public class Customer : BaseEntityWithLogFields
    {
        public string Identifier { get; set; }
        public Contact Profile { get; set; }
        public Guid? UserId { get; set; }
    }
}
