using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Inventory.Catalog
{
    [Table("Inventory.Catalog.CatalogItems")]
    public class CatalogItem : BaseEntityWithLogFields
    {
        public string Identifier { get; set; }
        public string ItemName { get; set; }

        public string ProductCode { get; set; }

        public virtual CategoryMaster Category { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        public CatalogBrand Brand { get; set; }

        [ForeignKey("Brand")]
        public Guid BrandId { get; set; }

        public string Image { get; set; }

        public double Price { get; set; }
        public double InsuranceAmount { get; set; }
        public double RoadTax { get; set; }
        public string HSN { get; set; }
        public double GST { get; set; }
        public Guid CompanyId { get; set; }
        public Guid TypeId { get; set; }
        public ICollection<CatalogItemPropertiesMap> Properties { get; set; }



    }
}
