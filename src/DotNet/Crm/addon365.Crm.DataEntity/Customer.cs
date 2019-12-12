using addon365.Common.DataEntity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Crm.DataEntity
{
    public class Customer : BaseEntityWithLogFields
    {
        public string Identifier { get; set; }

        public string CustomerEmailId { get; set; }
        public string MobileNo { get; set; }
        public Guid? ContactId { get; set; }
        [ForeignKey("ContactId")] public Contact Contact { get; set; }
        public Guid? BusinessContactId { get; set; }
        [ForeignKey("BusinessContactId")] public BusinessContact BusinessContact { get; set; }
        public Guid? UserId {get;set;}

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
