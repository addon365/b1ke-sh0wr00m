using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Inventory.Catalog
{
    [Table("Inventory.Catalog.CatalogBrands")]
    public class CatalogBrand : BaseEntityWithLogFields
    {
        public string Identifier { get; set; }
        public string CompanyName { get; set; }
        public int ProgrammerID { get; set; }
    }
}
