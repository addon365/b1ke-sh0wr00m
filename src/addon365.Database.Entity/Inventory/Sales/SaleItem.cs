using addon365.Database.Entity.Inventory.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Inventory.Sales
{
    [Table("Inventory.Sales.SalesItems")]
    public class SaleItem:BaseEntityWithLogFields
    {
        public Guid SalesId { get; set; }
        public Guid CatalogItemId { get; set; }
        [ForeignKey("CatalogItemId")] public virtual CatalogItem Product { get; set; }
        public decimal Price { get; set; }
        public double Quantity { get; set; }
        virtual public ICollection<SaleItemProperty> Properties { get; set; }

    }
}
