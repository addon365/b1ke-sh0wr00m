using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity.Inventory.Products
{
    public class ProductPropertiesMap:BaseEntity
    {
        public Guid ProductId{ get; set; }
        public Guid ItemPropertyMasterId { get; set; }
    }
}
