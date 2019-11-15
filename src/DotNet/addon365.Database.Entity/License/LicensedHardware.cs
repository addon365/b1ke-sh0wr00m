using addon365.Database.Entity.Inventory.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace addon365.Database.Entity.License
{
    [Table("AddonLicense.LicensedHardwares")]
    public class LicensedHardware : BaseEntity
    {
        public Guid CustomerCatalogGroupId { get; set; }
        [ForeignKey("CustomerCatalogGroupId")] public virtual CustomerCatalogGroup CustomerCatalogGroup { get; set; }
        public string HardwareId { get; set; }
        public string DeviceName { get; set; }
        public string MacAddress { get; set; }
        public DeviceType DeviceType { get; set; } 
        public string DeviceComment { get; set; }
        public DateTime ActivatedDate {get;set;}
        public DateTime EndDate { get; set; }
    }
    

}
