using addon365.Database.Entity.Accounts;
using addon365.Database.Entity.Crm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Inventory.Sales
{
    [Table("Inventory.Sales.Sales")]
    public class Sale : BaseEntityWithLogFields
    {
        public string BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public Guid? ShippingAddressId { get; set; }
        public Guid? BillingAddressId { get; set; }

        public Guid CustomerId { get; set; }
        [ForeignKey("CustomerId")] public virtual Customer Customer { get; set; }

        public Guid BuyerId { get; set; }
        [ForeignKey("BuyerId")] public virtual Buyer Buyer { get; set; }

        public Guid VoucherId { get; set; }
        [ForeignKey("VoucherId")] public virtual Voucher Voucher { get; set; }


        public virtual ICollection<SaleItem> Items { get; set; }


    }
}
