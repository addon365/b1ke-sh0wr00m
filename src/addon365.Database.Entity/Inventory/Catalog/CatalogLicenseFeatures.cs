using addon365.Database.Entity.Inventory.Sales;
using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Database.Entity.Inventory.Catalog
{
    public class CatalogLicenseFeatures
    {
        CatalogLicenseMaster CatalogLicense { get; set; }
        CatalogItem AddonItem { get; set; }

        DateTime AddedOn { get; set; }

        DateTime WarantyUpto { get; set; }

        DateTime ExpiryDate { get; set; }
        Sale Sale { get; set; }
    }
}
