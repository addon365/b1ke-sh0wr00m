using addon365.Common.DataEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace addon365.Chit.DataEntity
{
    [Table("Chit.ChitGroups")]
    public class ChitGroupTable: BaseEntity
    {
        public string  AccessId { get; set; }
        public string GroupName { get; set; }
        public Guid? ChitSchemeKeyId { get; set; }
        [ForeignKey("ChitSchemeKeyId")]
        public virtual ChitSchemeTable ChitSchema { get; set; }
        public Decimal ChitDueAmount { get; set; }
        public short TotalMember { get; set; }
        public short TotalDues { get; set; }
        public ChitPaymentFrequency PaymentFrequency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
