
using System.Collections.Generic;
using Api.Database.Entity.Accounts;
using Api.Database.Entity.Inventory;

namespace Api.Domain.Sales
{
    public class InsertSalesModel
    {
        public InventoryMaster Sales {get;set;}
        public IEnumerable<InventoryInfo> Inventorys { get; set; }
        public IEnumerable<InventoryItemMaster> itemMasters { get; set; }
        public IEnumerable<VoucherInfo> Amounts { get; set; }
      
    }
}
