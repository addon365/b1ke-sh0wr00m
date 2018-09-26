using Api.Database.Entity;
using Api.Database.Entity.Enquiries;
using Api.Database.Entity.Products;
using System;
using System.Collections.Generic;
using System.Text;

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
