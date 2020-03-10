using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Chit.DomainEntity
{
    public class ChitSubscriberDueModel
    {
        public Guid? KeyId  { get; set; }
        public string AccessId { get; set; }
        public Guid ChitSubscriberKeyId  { get; set; }
        public DateTime TransactionDate { get; set; }
        public Decimal Amount { get; set; }
    }
}
