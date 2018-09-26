using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity.ExchangeQuotations
{
    public class ExchangeQuotation:BaseEntity
    {
        public string Identifier { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int NoOfOwner { get; set; }
        public double Expected { get; set; }
        public double Quotated { get; set; }
    }
}
