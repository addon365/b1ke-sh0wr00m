using System;

namespace addon365.Chit.DomainEntity
{
    public class ChitSubscriberModel
    {
        public Guid ChitSubscriberKeyId { get; set; }
        public string ChitSubscriberAccessId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string Place { get; set; }
        public string Address { get; set; }
        public Guid ChitGroupKeyId { get; set; }

    }
}
