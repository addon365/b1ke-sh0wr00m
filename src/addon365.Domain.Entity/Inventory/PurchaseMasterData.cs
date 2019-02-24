using addon365.Database.Entity.Accounts;
using addon365.Database.Entity.Inventory;
using addon365.Database.Entity.Inventory.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Domain.Entity.Inventory
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
