﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace addon365.Database.Entity.Enquiries
{
    public class EnquiryExchangeQuotation:BaseEntityWithLogFields
    {
        public Guid EnquiryId { get; set; }
       // [ForeignKey("EnquiryId")] public virtual Enquiry enquiry { get; set; }
     
        public string Model { get; set; }
        public int Year { get; set; }
        public int NoOfOwner { get; set; }
        public double ExpectedAmount { get; set; }
        public double QuotatedAmount { get; set; }
    }
}
