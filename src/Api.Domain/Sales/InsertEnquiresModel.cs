
using System.Collections.Generic;
using Api.Database.Entity.Sales;

namespace Api.Domain.Sales
{
    public class InsertSalesModel
    {
        public SaleMaster Sales {get;set;}
        public IEnumerable<SalesInventorys> Inventorys { get; set; }
      
    }
}
