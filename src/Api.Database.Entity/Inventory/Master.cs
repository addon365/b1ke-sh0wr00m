using Api.Database.Entity.Crm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity.Inventory
{
    public class InventoryMaster:BaseEntity
    {
        public string Identifier { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
