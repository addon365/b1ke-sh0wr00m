using addon365.Database.Entity.Inventory.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Inventory.Purchases
{
    [Table("Inventory.Purchases.PurchasesItems")]
    public class PurchaseItem : BaseEntityWithLogFields
    {
        public Guid PurchaseId { get; set; }
        public Guid CatalogItemId { get; set; }
        [ForeignKey("CatalogItemId")] public virtual CatalogItem Product { get; set; }
        public decimal Price { get; set; }
        public decimal Unit { get; set; }
        public ICollection<PurchaseItemPropertyMap> ItemPropertyMaps { get; set; }
        [NotMapped]
        public decimal Amount { get { return Price * Unit; } }

    }

}
