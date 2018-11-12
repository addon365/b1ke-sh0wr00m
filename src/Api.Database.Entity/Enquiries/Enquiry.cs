﻿using Api.Database.Entity.Crm;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Database.Entity.Enquiries
{
    public class Enquiry:BaseEntity
    {

        public string Identifier { get; set; }
        public DateTime EnquiryDate { get; set; }
        public Guid ContactId { get; set; }
        [ForeignKey("ContactId")] public virtual Contact Contact { get; set; }

        public Guid EnquiryTypeId { get; set; }
        [ForeignKey("EnquiryTypeId")] public virtual EnquiryType EnquiryType { get; set; }

        public Guid StatusId { get; set; }
        [ForeignKey("StatusId")] public virtual EnquiryStatus Status { get; set; }

        public IIncludableQueryable<Enquiry, object> Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
