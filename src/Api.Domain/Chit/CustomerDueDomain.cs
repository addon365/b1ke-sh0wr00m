namespace Api.Domain.Chit
{
    public class CustomerDueDomain
    {
        public string SubscriptionId { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public double PaidAmount { get; set; }
        public double BalanceAmount { get; set; }
    }
}
