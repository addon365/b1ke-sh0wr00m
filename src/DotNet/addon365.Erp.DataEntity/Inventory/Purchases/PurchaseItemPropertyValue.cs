using addon365.Database.Entity.Inventory.Catalog;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Inventory.Purchases
{
    [Table("Inventory.Purchases.PurchasesItemsPropertiesValues")]
    public class PurchaseItemPropertyValue : BaseEntity
    {

        public Guid PurchaseItemPropertyMapId { get; set; }

        public Guid CatalogPropertyMasterId { get; set; }
        [ForeignKey("CatalogPropertyMasterId")] public virtual CatalogItemPropertyMaster CatalogItemPropertyMaster { get; set; }
        public string Value { get; set; }

    }
}
