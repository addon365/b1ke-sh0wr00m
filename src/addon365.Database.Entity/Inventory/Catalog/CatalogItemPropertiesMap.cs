using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Inventory.Catalog
{
    [Table("Inventory.Catalog.CatalogItemPropertiesMaps")]
    public class CatalogItemPropertiesMap : BaseEntity
    {
        public Guid CatalogItemId { get; set; }
        //[ForeignKey("ProductId")] public Product Product { get; set; }
        public Guid CatalogPropertyMasterId { get; set; }
        [ForeignKey("CatalogPropertyMasterId")] public virtual CatalogItemPropertyMaster PropertyMaster { get; set; }
        public int ValueType { get; set; }
    }
}
