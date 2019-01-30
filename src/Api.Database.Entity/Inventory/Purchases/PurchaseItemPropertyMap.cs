using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Database.Entity.Inventory.Purchases
{
    [Table("Inventory.Purchases.PurchaseItemPropertyMap")]
    public class PurchaseItemPropertyMap:BaseEntity
    {
        public Guid PurchaseItemId { get; set; }
        [ForeignKey("PurchaseItemId")] public virtual PurchaseItem PurchaseItem { get; set; }
        public decimal Unit { get; set; }
        public ICollection<PurchaseItemPropertyValue> PropertyValues { get; set; }
    }
}
