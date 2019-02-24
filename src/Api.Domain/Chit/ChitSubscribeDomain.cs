using System;

namespace addon365.Domain.Entity.Chit
{
    public class ChitSubscribeDomain
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public double Amount { get; set; }
        public Guid ChitSchemeId { get; set; }
        public string FieldInfo { get; set; }
        public Guid SubscribeId { get; set; }
    }
}
