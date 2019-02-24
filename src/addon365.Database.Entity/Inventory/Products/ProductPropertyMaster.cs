using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Inventory.Products
{
    [Table("Inventory.Products.ProductsPropertiesMasters")]
    public class ProductPropertyMaster:BaseEntityWithLogFields
    {
        public string PropertyName { get; set; }
    }
}
