using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity.Inventory.Products
{
    [Table("Inventory.Products.ProductType")]
    public class ProductType : BaseEntityWithLogFields
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public Guid ParentId { get; set; }
        public int ProgrammerId { get; set; }
    }
}
