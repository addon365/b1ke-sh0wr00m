using addon365.Database.Entity.Crm;
using addon365.Database.Entity.Employees;
using addon365.Database.Entity.Inventory.Sales;
using addon365.Database.Entity.License;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace addon365.Database.Entity.Inventory.Catalog
{
    [Table("Inventory.Catalog.CustomerCatalogGroup")]
    public class CustomerCatalogGroup : BaseEntity
    {
        public string CustomerCatalogGroupId { get; set; }
        public Guid? CustomerId { get; set; }
        [ForeignKey("CustomerId")] public Customer Customer { get; set; }

        public Guid? CatalogItemId { get; set; }
        [ForeignKey("CatalogItemId")] public CatalogItem Item { get; set; }

        public int NumberofSystem { get; set; }
        public Guid? SaleId { get; set; }
        [ForeignKey("SaleId")] public Sale Sale { get; set; }
        public DateTime ActivatedOn { get; set; }
        public Guid? RenewedDetailId { get; set; }
        [ForeignKey("RenewedDetailId")] public LicenseRenewedDetail RenewedDetail { get; set; }
        public Guid? EmployeeId { get; set; }
        [ForeignKey("EmployeeId")] public Employee CreatedEmployee { get; set; }

    }
}
