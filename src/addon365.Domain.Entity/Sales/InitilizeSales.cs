using addon365.Database.Entity;
using addon365.Database.Entity.Accounts;
using addon365.Database.Entity.Enquiries;
using addon365.Database.Entity.Finance;
using addon365.Database.Entity.Inventory.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Domain.Entity.Sales
{
    public class InitilizeSales
    {
        public IEnumerable<MarketingZone> MarketingZones { get; set; }
        public IEnumerable<CatalogItem> CatalogItems { get; set; }
        public IEnumerable<PaymentMode> PaymentModes { get; set; }
        public IEnumerable<FinanceCompany> FinanceCompanies { get; set; }
    }
}
