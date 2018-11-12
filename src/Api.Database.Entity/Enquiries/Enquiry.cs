using Api.Database.Entity.Crm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Database.Entity.Enquiries
{
    public class Enquiry:BaseEntity
    {

        public string Identifier { get; set; }
        public Guid ContactId { get; set; }
        [ForeignKey("ContactId")] public virtual Contact Contact { get; set; }

        public Guid EnquiryTypeId { get; set; }
        [ForeignKey("EnquiryTypeId")] public virtual EnquiryType EnquiryType { get; set; }

        public Guid StatusId { get; set; }
        [ForeignKey("StatusId")] public virtual EnquiryStatus Status { get; set; }

        public List<EnquiryProduct> EnquiryProducts { get; set; }
    }
}
