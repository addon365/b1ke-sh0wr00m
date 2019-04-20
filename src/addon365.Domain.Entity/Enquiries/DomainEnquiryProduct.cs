using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Domain.Entity.Enquiries
{
    public class DomainEnquiryProduct
    {

            public Guid Id { get; set; }
            public Guid EnquiryId { get; set; }
            public Guid ProductId { get; set; }
            public string ItemName { get; set; }
            public double OnRoadPrice { get; set; }
            public double AccessoriesAmount { get; set; }
            public double OtherAmount { get; set; }
            public double TotalAmount { get; set; }
                
    }
}
