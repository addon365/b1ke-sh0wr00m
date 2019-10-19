using addon365.Database.Entity.Crm;
using addon365.Database.Entity.Employees;
using addon365.Database.Entity.Inventory.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace addon365.Database.Entity.Inventory.Catalog
{
    [Table("Inventory.Catalog.CustomerCatalogGroup")]
    public class CustomerCatalogGroup:BaseEntity
    {
        public string CustomerCatalogGroupId { get; set; }
        public Customer Customer { get; set; }
        public CatalogItem Item { get; set; }
        public Sale Sale { get; set; }
        public DateTime ActivatedOn { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Employee CreatedEmployee { get; set; }

    }
}
