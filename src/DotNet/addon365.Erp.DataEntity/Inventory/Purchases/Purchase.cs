using addon365.Database.Entity.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Inventory.Purchases
{
    [Table("Inventory.Purchases.Purchases")]
    public class Purchase : BaseEntityWithLogFields
    {
        public string PurchaseInvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Guid SellerId { get; set; }
        [ForeignKey("SellerId")] public virtual Seller Seller { get; set; }
        public virtual ICollection<PurchaseItem> Items { get; set; }

        public Guid? VoucherId { get; set; }
        [ForeignKey("VoucherId")]
        public virtual Voucher Voucher { get; set; }

    }
}
