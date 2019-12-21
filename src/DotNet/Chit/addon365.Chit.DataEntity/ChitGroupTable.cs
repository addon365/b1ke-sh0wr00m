using addon365.Common.DataEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace addon365.Chit.DataEntity
{
    public class ChitGroupTable: BaseEntityWithLogFields
    {
        public string  ChitGroupAccessId { get; set; }
        public string GroupName { get; set; }
        public Guid? ChitSchemeKeyId { get; set; }
        [ForeignKey("ChitSchemeKeyId")]
        public virtual ChitSchemeTable ChitSchema { get; set; }
        public Decimal Amount { get; set; }
        public short TotalMember { get; set; }
        public short TotalDues { get; set; }
        public ChitPaymentFrequency PaymentFrequency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
