using System;

namespace addon365.Chit.DomainEntity
{
    public class ChitGroupModel 
    {
      
        public Guid KeyId { get; set; }
        public string AccessId { get; set; }
        public string GroupName { get; set; }
        public short TotalDues { get; set; }
        public DateTime StartDate { get; set; }
        public bool HasFixedDate { get; set; }
        public int MaxMembers { get; set; }
        public Decimal ChitDueAmount { get; set; }
      
    }
}
