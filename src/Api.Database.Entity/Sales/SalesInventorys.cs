using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity.Sales
{
    class SalesInventorys
    {
        public Guid SalesId { get; set; }
        public Guid ProductId { get; set; }
        public double UnitPrice { get; set; }
        public double Discount { get; set; }
    }
}
