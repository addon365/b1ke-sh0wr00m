using System;

namespace addon365.Chit.DomainEntity
{
    public class ChitSubscriberModel
    {
        public Guid KeyId { get; set; }
        public string AccessId { get; set; }
       public CustomerModel Customer { get; set; }
        public ChitGroupModel ChitGroup { get; set; }
        public AgentModel Agent { get; set; }
        public decimal ChitDueAmount { get; set; }

    }
}
