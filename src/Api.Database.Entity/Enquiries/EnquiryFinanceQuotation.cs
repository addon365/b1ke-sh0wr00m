using Api.Database.Entity.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Database.Entity.Enquiries
{
    public class EnquiryFinanceQuotation:BaseEntity
    {
        public Guid EnquiryProductId { get; set; }
        //[ForeignKey("EnquiryProductId")] public virtual EnquiryProduct enquiryProduct { get; set; }
     
        public double InitialDownPayment { get; set; }
        public double MonthlyEMIAmount { get; set; }
        public int NumberOfMonths { get; set; }
    }
}
