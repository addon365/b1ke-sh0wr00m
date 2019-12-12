using addon365.Common.DataEntity;
using System;

namespace addon365.Chit.DataEntity
{
    public class ChitScheme : BaseEntityWithLogFields
    {
        public string SchemaName { get; set; }
        public int TotalMonths { get; set; }
        public DateTime StartDate { get; set; }
        public bool HasFixedDate { get; set; }
        public int MaxMembers { get; set; }
        public double MonthlyAmount { get; set; }
        public double BonusAmount { get; set; }
        public double FinalBonus { get; set; }
    }
}
