using addon365.Database.Entity.Inventory.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace addon365.Database.Entity.Inventory.Catalog
{
    [Table("Inventory.Catalog.CustomerCatalogGroupDetail")]
    public class CustomerCatalogGroupDetail:BaseEntity
    {
        public CustomerCatalogGroup CatalogGroup { get; set; }
        public CatalogItem AddonItem { get; set; }

        public DateTime AddedOn { get; set; }

        public DateTime WarantyUpto { get; set; }

        public DateTime ExpiryDate { get; set; }
        public Sale Sale { get; set; }
    }
}
