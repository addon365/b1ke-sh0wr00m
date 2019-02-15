using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Api.Database.Entity.Inventory.Products;
namespace Api.Database.Entity.Enquiries
{
    public class EnquiryProduct:BaseEntityWithLogFields
    {
        public Guid EnquiryId { get; set; }
        public Guid ProductId { get; set; }
        public double OnRoadPrice { get; set; }
        public double AccessoriesAmount { get; set; }
        public double OtherAmount { get; set; }
        public double TotalAmount { get; set; }
        public IList<EnquiryFinanceQuotation> EnquiryFinanceQuotations { get; set; }
        //[ForeignKey("EnquiryId")] public virtual Enquiry Enquiry { get; set; }
        [ForeignKey("ProductId")] public virtual Product Product { get; set; }
         
    }
}
