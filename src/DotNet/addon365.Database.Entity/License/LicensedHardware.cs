using addon365.Database.Entity.Inventory.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace addon365.Database.Entity.License
{
    public class LicensedHardware : BaseEntity
    {
        public Guid CustomerCatalogGroupId { get; set; }
        [ForeignKey("CustomerCatalogGroupId")] public virtual CustomerCatalogGroup CustomerCatalogGroup { get; set; }
        public string HardwareId { get; set; }
        public DateTime ActivatedDate {get;set;}
        public DateTime EndDate { get; set; }
    }
}
