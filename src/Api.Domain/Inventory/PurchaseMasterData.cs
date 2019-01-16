using Api.Database.Entity.Inventory.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.Inventory
{
    public class PurchaseMasterData
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
