using System;

namespace addon365.Chit.DomainEntity
{
    public class ChitGroupModel 
    {
        public Guid KeyId { get; set; }
        public string GroupName { get; set; }
        public int TotalMonths { get; set; }
        public DateTime StartDate { get; set; }
        public bool HasFixedDate { get; set; }
        public int MaxMembers { get; set; }
        public Decimal Amount { get; set; }
      
    }
}
