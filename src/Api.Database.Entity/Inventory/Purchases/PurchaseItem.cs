using Api.Database.Entity.Inventory.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity.Inventory.Purchases
{
    [Table("Inventory.Purchases.PurchaseItem")]
    public class PurchaseItem : BaseEntityWithLogFields
    {
        public Guid PurchaseId { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")] public virtual Product Product { get; set; }
        public decimal Price { get; set; }
        public decimal Unit { get; set; }
        public ICollection<PurchaseItemPropertyMap> ItemPropertyMaps { get; set; }
        [NotMapped]
        public decimal Amount { get { return Price * Unit; } }

    }
    
}
