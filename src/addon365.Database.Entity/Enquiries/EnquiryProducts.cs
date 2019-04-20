using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using addon365.Database.Entity.Inventory.Catalog;
namespace addon365.Database.Entity.Enquiries
{
    public class EnquiryCatalogItem:BaseEntityWithLogFields
    {
        public Guid EnquiryId { get; set; }
        public Guid CatalogItemId { get; set; }
        public double OnRoadPrice { get; set; }
        public double AccessoriesAmount { get; set; }
        public double OtherAmount { get; set; }
        public double TotalAmount { get; set; }
        public IList<EnquiryFinanceQuotation> EnquiryFinanceQuotations { get; set; }
        //[ForeignKey("EnquiryId")] public virtual Enquiry Enquiry { get; set; }
        [ForeignKey("CatalogItemId")] public virtual CatalogItem Item { get; set; }
         
    }
}
