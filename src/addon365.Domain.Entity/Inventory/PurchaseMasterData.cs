using addon365.Database.Entity.Accounts;
using addon365.Database.Entity.Inventory;
using addon365.Database.Entity.Inventory.Catalog;
using System.Collections.Generic;

namespace addon365.Domain.Entity.Inventory
{
    public class PurchaseMasterData
    {
        public IEnumerable<CatalogItem> CatalogItems { get; set; }
        public IEnumerable<Seller> Sellers { get; set; }
        public AccountBook PurchaseBook { get; set; }
        public AccountBook GstBook { get; set; }
        public AccountBook CashBook { get; set; }
        public VoucherTypeMaster VoucherTypeMaster { get; set; }
    }
}
