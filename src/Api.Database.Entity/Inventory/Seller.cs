using Api.Database.Entity.Crm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity.Inventory
{
    public class Seller:BaseEntityWithLogFields
    {
        public string SellerId { get; set; }
        public BusinessContact BusinessContact { get; set; }
        public Guid? UserId { get; set; }
    }
}
