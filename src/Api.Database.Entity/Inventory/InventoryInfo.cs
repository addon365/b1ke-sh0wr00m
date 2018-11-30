using System;

namespace Api.Database.Entity.Inventory
{
    public class InventoryInfo:BaseEntity
    {
        public Guid InventoryMasterId { get; set; }
        public Guid ProductId { get; set; }
        public double Unit { get; set; }
        public double UnitPrice { get; set; }
        public double Discount { get; set; }
        public Guid InventoryItemMasterId { get; set; }
    }
}
