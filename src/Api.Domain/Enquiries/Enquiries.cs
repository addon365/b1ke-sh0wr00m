using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Api.Database.Entity.Enquiries;
using System.ComponentModel.DataAnnotations;
using Api.Database.Entity.Crm;

namespace Api.Domain.Enquiries
{
    public class Enquiries
    {
       

            public Contact Contact { get; set; }
            public  EnquiryType EnquiryType { get; set; }
            public EnquiryStatus Status { get; set; }
            public EnquiryProduct EnquiryProducts { get; set; }
            public EnquiryFinanceQuotation EnquiryFinanceQuotations { get; set; }
            public EnquiryExchangeQuotation EnquiryExchangeQuotations { get; set; }

    }
}
