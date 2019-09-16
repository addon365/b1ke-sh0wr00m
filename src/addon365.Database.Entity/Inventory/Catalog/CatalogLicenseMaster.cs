using addon365.Database.Entity.Crm;
using addon365.Database.Entity.Inventory.Sales;
using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Database.Entity.Inventory.Catalog
{
    public class CatalogLicenseMaster:BaseEntity
    {
        string CatalogLicenseId { get; set; }
        Customer Customer { get; set; }
        CatalogItem MainItem { get; set; }
        Sale Sale { get; set; }

    }
}
