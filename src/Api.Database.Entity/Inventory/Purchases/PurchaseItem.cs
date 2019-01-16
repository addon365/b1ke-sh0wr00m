using Api.Database.Entity.Inventory.Products;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity.Inventory.Purchase
{
    public class PurchaseItem : BaseEntityWithLogFields
    {
        public Guid PurchaseId { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")] public virtual Product Product { get; set; }
        public decimal Price { get; set; }
        public double Quantity { get; set; }

    }
    
}
