using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace addon365.Database.Entity.Inventory.Catalog
{
    [Table("Inventory.Products.ExtraFittingsAccessories")]
    public class ExtraFittingsAccessories:BaseEntityWithLogFields
    {
        public Guid CatalogItemId { get; set; }
        [ForeignKey("CatalogItemId")] public virtual CatalogItem CatalogItem { get; set; }
        public Guid AccessoriesProductId { get; set; }
        public virtual CatalogItem AccessoriesProductItem { get; set; }
        public double Unit { get; set; }
        public double UnitPrice { get; set; }
        public virtual double Amount { get; set; }
            
        

        //[ForeignKey("AccessoriesProductId")] public virtual Product accessoriesproduct { get; set; }
    }
}
