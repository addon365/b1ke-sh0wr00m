using Api.Database.Entity;
using Api.Database.Entity.Accounts;
using Api.Database.Entity.Enquiries;
using Api.Database.Entity.Finance;
using Api.Database.Entity.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.Sales
{
    public class InitilizeSales
    {
        public IEnumerable<MarketingZone> MarketingZones { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<PaymentMode> PaymentModes { get; set; }
        public IEnumerable<FinanceCompany> FinanceCompanies { get; set; }
    }
}
