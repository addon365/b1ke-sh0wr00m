using System;

namespace addon365.Database.Entity.Enquiries
{
    public class EnquiryFinanceQuotation : BaseEntityWithLogFields
    {
        public Guid EnquiryProductId { get; set; }
        public double InitialDownPayment { get; set; }
        public double MonthlyEMIAmount { get; set; }
        public int NumberOfMonths { get; set; }
    }
}
