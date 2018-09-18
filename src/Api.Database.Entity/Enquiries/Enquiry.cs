using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Database.Entity.Enquiries
{
    public class Enquiry:BaseEntity
    {

        public string Identifier { get; set; }
        public Guid ProfileId { get; set; }
        [ForeignKey("ProfileId")] public virtual Profile Profile { get; set; }

        public Guid EnquiryTypeId { get; set; }
        [ForeignKey("EnquiryTypeId")] public virtual EnquiryType EnquiryType { get; set; }

        public Guid StatusId { get; set; }
        [ForeignKey("StatusId")] public virtual EnquiryStatus Status { get; set; }
    }
}
