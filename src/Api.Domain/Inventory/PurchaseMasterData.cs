using Api.Database.Entity.Accounts;
using Api.Database.Entity.Inventory;
using Api.Database.Entity.Inventory.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.Inventory
{
    public class PurchaseMasterData
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Seller> Sellers { get; set; }
        public AccountBook PurchaseBook { get; set; }
        public AccountBook GstBook { get; set; }
        public AccountBook CashBook { get; set; }
        public VoucherTypeMaster VoucherTypeMaster { get; set; }
    }
}
