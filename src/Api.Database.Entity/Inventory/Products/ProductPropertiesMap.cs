using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity.Inventory.Products
{
    [Table("Inventory.Products.ProductPropertiesMap")]
    public class ProductPropertiesMap:BaseEntity
    {
        public Guid ProductId{ get; set; }
       //[ForeignKey("ProductId")] public Product Product { get; set; }
        public Guid ProductPropertyMasterId { get; set; }
        [ForeignKey("ProductPropertyMasterId")] public virtual ProductPropertyMaster PropertyMaster { get; set; }
        public int ValueType { get; set; }
    }
}
