using addon365.Database.Entity;
using addon365.Database.Entity.License;
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
        public string MacAddress { get; set; }
        public string DeviceName { get; set; }
        public DeviceType DeviceType { get; set; }
        public string DeviceComment { get; set; }
        public ActivateCallType CallType { get; set; }
    }
}
