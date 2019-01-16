using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity.Inventory.Purchase
{
    public class PurchaseItemProperty:BaseEntity
    {
        public Guid PurchaseItemsId { get; set; }
        public Guid ProductPropertyMasterId { get; set; }
        public string Value { get; set; }
        public Guid GroupId { get; set; }
    }
}
