using addon365.Database.Entity.Chit;
using System.Collections.Generic;

namespace addon365.Domain.Entity.Chit
{
    public class CustomerDueDomain
    {
        public string SubscriptionId { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public double PaidAmount { get; set; }
        public double BalanceAmount { get; set; }
        public static IList<CustomerDueDomain> FromList(IList<ChitSubriberDue> dues)
        {
            IList<CustomerDueDomain> customerDues = new List<CustomerDueDomain>();
            foreach (var due in dues)
            {
                customerDues.Add(FromSingle(due));
            }
            return customerDues;
        }
        public static CustomerDueDomain FromSingle(ChitSubriberDue due)
        {
            CustomerDueDomain dueDomain = new CustomerDueDomain()
            {
                SubscriptionId = due.ChitSubscriber.SubscribeId,
                Amount = due.ChitSubscriber.ChitSchema.MonthlyAmount,
                Name = due.ChitSubscriber.Customer.Profile.FirstName
            };
            return dueDomain;
        }
    }
}
