using addon365.Database.Entity.Accounts;
using addon365.Database.Entity.Crm;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace addon365.Database.Entity.Enquiries
{
    public class Enquiry:BaseEntityWithLogFields
    {

        public string Identifier { get; set; }
        public DateTime EnquiryDate { get; set; }
        public Guid ContactId { get; set; }
        [ForeignKey("ContactId")] public virtual Contact Contact { get; set; }

        public Guid EnquiryTypeId { get; set; }
        [ForeignKey("EnquiryTypeId")] public virtual EnquiryType EnquiryType { get; set; }

        public Guid StatusId { get; set; }
        [ForeignKey("StatusId")] public virtual EnquiryStatus Status { get; set; }

        public ICollection<EnquiryProduct> EnquiryProducts { get; set; }
       
        public ICollection<EnquiryExchangeQuotation> EnquiryExchangeQuotations { get; set; }

        public Guid? VoucherId { get; set; }

        [ForeignKey("VoucherId")]
        public virtual Voucher Voucher { get; set; }

        public IOrderedQueryable<Enquiry> OrderBy(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
