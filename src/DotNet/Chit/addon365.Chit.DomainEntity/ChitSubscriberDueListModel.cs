using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Chit.DomainEntity
{
    public class ChitSubscriberDueListModel
    {
        public Guid? KeyId  { get; set; }
        public string AccessId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string Place { get; set; }
        public string GroupName { get; set; }
        public Guid ChitSubscriberKeyId  { get; set; }
        public DateTime TransactionDate { get; set; }
        public Decimal Amount { get; set; }
    }
}
