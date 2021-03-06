﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Inventory.Purchases
{
    [Table("Inventory.Purchases.PurchasesItemsPropertiesMaps")]
    public class PurchaseItemPropertyMap : BaseEntity
    {
        public Guid PurchaseItemId { get; set; }
        [ForeignKey("PurchaseItemId")] public virtual PurchaseItem PurchaseItem { get; set; }
        public decimal Unit { get; set; }
        public ICollection<PurchaseItemPropertyValue> PropertyValues { get; set; }
    }
}
