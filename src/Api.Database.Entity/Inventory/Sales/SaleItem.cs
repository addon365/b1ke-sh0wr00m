using Api.Database.Entity.Inventory.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity.Inventory.Sales
{
    [Table("Inventory.Sales.SalesItems")]
    public class SaleItem:BaseEntityWithLogFields
    {
        public Guid SalesId { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")] public virtual Product Product { get; set; }
        public decimal Price { get; set; }
        public double Quantity { get; set; }
        virtual public ICollection<SaleItemProperty> Properties { get; set; }

    }
}
