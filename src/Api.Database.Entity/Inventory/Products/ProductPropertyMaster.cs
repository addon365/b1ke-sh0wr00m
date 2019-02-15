using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity.Inventory.Products
{
    [Table("Inventory.Products.ProductsPropertiesMasters")]
    public class ProductPropertyMaster:BaseEntityWithLogFields
    {
        public string PropertyName { get; set; }
    }
}
