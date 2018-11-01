using System;

namespace Api.Database.Entity.Sales
{
    public class SalesInventorys
    {
        public Guid SalesId { get; set; }
        public Guid ProductId { get; set; }
        public double UnitPrice { get; set; }
        public double Discount { get; set; }
    }
}
