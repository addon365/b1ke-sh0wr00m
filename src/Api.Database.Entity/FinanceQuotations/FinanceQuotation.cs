using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity.FinanceQuotations
{
    public class FinanceQuotation:BaseEntity
    {
        public string Identifier { get; set; }
        public double DownPayment { get; set; }
        public double EMIAmount { get; set; }
        public int TenureInMonths { get; set; }
    }
}
