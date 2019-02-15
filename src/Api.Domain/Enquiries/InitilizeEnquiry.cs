using Api.Database.Entity;
using Api.Database.Entity.Enquiries;
using Api.Database.Entity.Inventory.Products;
using System.Collections.Generic;

namespace Api.Domain.Enquiries
{
    public class InitilizeEnquiry
    {
        public IEnumerable<MarketingZone> MarketingZones { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ExtraFittingsAccessories> ExtraAccessories { get; set; }
        public IEnumerable<EnquiryType> enquiryTypes { get; set; }
    }
}
