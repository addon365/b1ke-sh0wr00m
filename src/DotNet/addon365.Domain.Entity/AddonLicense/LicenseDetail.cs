using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Domain.Entity.AddonLicense
{
    public class LicenseDetail
    {
        public string CustomerCatalogGroupId { get; set; }
        public string BusinessName { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactMobileNo { get; set; }
        public int NumberofSystem { get; set; }
        public int ActiveSystemCount { get; set; }
        public DateTime ExpiryDate { get; set; }

    }
}
