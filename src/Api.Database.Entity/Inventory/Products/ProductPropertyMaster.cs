using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity.Inventory.Products
{
    public class ProductPropertyMaster:BaseEntityWithLogFields
    {
        public string PropertyMasterId { get; set; }
        public string PropertyName { get; set; }
    }
}
