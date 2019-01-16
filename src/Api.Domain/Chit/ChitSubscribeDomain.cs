using System;

namespace Api.Domain.Chit
{
    public class ChitSubscribeDomain
    {
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public double Amount { get; set; }
        public Guid ChitSchemeId { get; set; }
        public string FieldInfo { get; set; }
        public Guid SubscribeId { get; set; }
    }
}
