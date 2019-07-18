using addon365.Database.Entity.Inventory.Catalog;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Enquiries
{
    public class EnquiryAccessories : BaseEntityWithLogFields
    {
        public Guid EnquiryId { get; set; }
        [ForeignKey("EnquiryId")] public virtual Enquiry enquiry { get; set; }

        public Guid CatalogItemId { get; set; }
        [ForeignKey("CatalogItemId")] public virtual CatalogItem product { get; set; }
        public Guid AccessoriesId { get; set; }
    }
}
