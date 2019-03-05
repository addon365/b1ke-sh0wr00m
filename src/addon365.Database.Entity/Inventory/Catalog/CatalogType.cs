using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Inventory.Catalog
{
    [Table("Inventory.Catalog.CatalogTypes")]
    public class CatalogType : BaseEntityWithLogFields
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public Guid ParentId { get; set; }
        public int ProgrammerId { get; set; }
    }
}
