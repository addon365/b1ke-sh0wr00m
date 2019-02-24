using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Inventory.Products
{
    [Table("Inventory.Products.ProductsPropertiesValueChoices")]
    public class ProductPropertiesValueChoice:BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid ItemPropertyMasterId { get; set; }
        public string ChoiceValue { get; set; }
    }
}
