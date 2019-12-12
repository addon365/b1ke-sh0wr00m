using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Inventory.Catalog
{
    [Table("Inventory.Catalog.CatalogItemPropertiesValueChoices")]
    public class CatalogItemPropertiesValueChoice : BaseEntity
    {
        public Guid CatalogItemId { get; set; }
        public Guid ItemPropertyMasterId { get; set; }
        public string ChoiceValue { get; set; }
    }
}
