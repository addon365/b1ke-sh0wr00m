using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Inventory.Catalog
{
    [Table("Inventory.Catalog.CatalogItemPropertyMasters")]
    public class CatalogItemPropertyMaster : BaseEntityWithLogFields
    {
        public string PropertyName { get; set; }
    }
}
