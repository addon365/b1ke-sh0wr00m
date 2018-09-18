using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity.Enquiries
{
    public class EnquiryExchangeQuotation:BaseEntity
    {
        public string EnquiryId { get; set; }
        public string ExchangeQuotationId { get; set; }
    }
}
