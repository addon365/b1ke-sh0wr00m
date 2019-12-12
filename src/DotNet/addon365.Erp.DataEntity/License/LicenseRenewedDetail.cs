using addon365.Database.Entity.Accounts;
using addon365.Database.Entity.Inventory.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace addon365.Database.Entity.License
{
    [Table("AddonLicense.LicenseRenewedDetails")]
    public class LicenseRenewedDetail : BaseEntity
    {
        public Guid CustomerCatalogGroupId { get; set; }
        [ForeignKey("CustomerCatalogGroupId")] public virtual CustomerCatalogGroup CustomerCatalogGroup { get; set; }
        public DateTime RenewedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool Activated { get; set; }
        public DateTime ActivateDate { get; set; }
        public string ActivateComment { get; set; }
        public Guid? VoucherId { get; set; }

        [ForeignKey("VoucherId")]
        public virtual Voucher Voucher { get; set; }
    }
}
