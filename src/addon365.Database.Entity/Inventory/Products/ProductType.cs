using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Inventory.Products
{
    [Table("Inventory.Products.ProductTypes")]
    public class ProductType : BaseEntityWithLogFields
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public Guid ParentId { get; set; }
        public int ProgrammerId { get; set; }
    }
}
