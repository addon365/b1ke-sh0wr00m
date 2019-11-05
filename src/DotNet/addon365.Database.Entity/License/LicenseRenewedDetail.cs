using addon365.Database.Entity.Accounts;
using addon365.Database.Entity.Inventory.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace addon365.Database.Entity.License
{
    public class LicenseRenewedDetail : BaseEntity
    {
        public Guid CustomerCatalogGroupId { get; set; }
        [ForeignKey("CustomerCatalogGroupId")] public virtual CustomerCatalogGroup CustomerCatalogGroup { get; set; }
        public DateTime RenewedOn { get; set; }
        public DateTime ExpiryOn { get; set; }
        public Guid? VoucherId { get; set; }

        [ForeignKey("VoucherId")]
        public virtual Voucher Voucher { get; set; }
    }
}
