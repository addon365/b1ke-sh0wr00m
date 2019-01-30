using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Database.Entity.Inventory.Purchases
{
    [Table("Inventory.Purchases.Purchase")]
    public class Purchase : BaseEntityWithLogFields
    {
        public string PurchaseInvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Guid BusinessContactId { get; set; }
        [ForeignKey("BusinessContactId")] public virtual Seller Seller { get; set; }
        public virtual ICollection<PurchaseItem> Items { get; set; }
        
    }
}
