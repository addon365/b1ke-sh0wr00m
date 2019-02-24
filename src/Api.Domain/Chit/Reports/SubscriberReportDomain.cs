using System;

namespace Api.Domain.Chit.Reports
{
    public class SubscriberReportDomain
    {
        public string CustomerName { get; set; }
        public bool IsClosed { get; set; }
        public double MonthlyAmount { get; set; }
        public int PaidMonth { get; set; }
        public string SchemeName { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public string SubscriptionId { get; set; }
        public double PendingAmount { get; set; }
    }
}
