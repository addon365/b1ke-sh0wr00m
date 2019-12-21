using addon365.Common.DataEntity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Crm.DataEntity
{
    public class CustomerTable : BaseEntityWithLogFields
    {
        public string Identifier { get; set; }

        public string CustomerEmailId { get; set; }
        public string MobileNo { get; set; }
        public Guid? ContactKeyId { get; set; }
        [ForeignKey("ContactKeyId")] public ContactTable Contact { get; set; }
        public Guid? BusinessContactKeyId { get; set; }
        [ForeignKey("BusinessContactKeyId")] public BusinessContactTable BusinessContact { get; set; }
        public Guid? UserKeyId {get;set;}

        [ForeignKey("UserKeyId")]
        public User User { get; set; }
    }
}
