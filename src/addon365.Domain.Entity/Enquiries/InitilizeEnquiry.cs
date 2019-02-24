using addon365.Database.Entity;
using addon365.Database.Entity.Enquiries;
using addon365.Database.Entity.Inventory.Products;
using System.Collections.Generic;

namespace addon365.Domain.Entity.Enquiries
{
    public class InitilizeEnquiry
    {
        public IEnumerable<MarketingZone> MarketingZones { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ExtraFittingsAccessories> ExtraAccessories { get; set; }
        public IEnumerable<EnquiryType> enquiryTypes { get; set; }
    }
}
