using addon365.Common.DataEntity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Chit.DataEntity
{
    [Table("Chit.ChitSchemes")]
    public class ChitSchemeTable : BaseEntity
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
