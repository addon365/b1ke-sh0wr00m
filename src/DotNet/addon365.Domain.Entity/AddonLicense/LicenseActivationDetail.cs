using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Domain.Entity.AddonLicense
{
    public class LicenseActivationDetail
    {

        public string CustomerCatalogGroupId { get; set; }
        public string BusinessName { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string ContactPersonName { get; set; }
        public string HardwareId { get; set; }
        public ActivateCallType CallType { get; set; }
    }
}
