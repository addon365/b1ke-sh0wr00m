using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity.Inventory.Products
{
    [Table("Inventory.Products.ProductPropertiesValueChoice")]
    public class ProductPropertiesValueChoice:BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid ItemPropertyMasterId { get; set; }
        public string ChoiceValue { get; set; }
    }
}
