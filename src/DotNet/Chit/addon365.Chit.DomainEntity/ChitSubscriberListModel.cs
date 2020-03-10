using System;

namespace addon365.Chit.DomainEntity
{
    public class ChitSubscriberListModel
    {
        public Guid KeyId { get; set; }
        public string AccessId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string Place { get; set; }
        public string Address { get; set; }
        public Guid ChitGroupKeyId { get; set; }
        public string ChitGroupName { get; set; }

        public AgentModel Agent { get; set; }

        public int TotalDue { get; set; }

        public int PaidDue { get; set; }
    }
}
