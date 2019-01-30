using Api.Database.Entity.Inventory.Products;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity.Inventory.Purchases
{
    [Table("Inventory.Purchases.PurchaseItemPropertyValue")]
    public class PurchaseItemPropertyValue:BaseEntity
    {
      
        public Guid PurchaseItemPropertyMapId { get; set; }
     
        public Guid ProductPropertyMasterId { get; set; }
        [ForeignKey("ProductPropertyMasterId")] public virtual ProductPropertyMaster ProductPropertyMaster { get; set; }
        public string Value { get; set; }
      
    }
}
