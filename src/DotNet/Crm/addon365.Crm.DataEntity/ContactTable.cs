using addon365.Common.DataEntity;
using addon365.Crm.DataEntity.Address;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Crm.DataEntity
{
    [Table("Crm.Contacts")]
    public class ContactTable : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string SecondaryMobileNo { get; set; }
        public string Place { get; set; }
        public AddressTable ContactAddress { get; set; }
        public string Address { get; set; }
        public Guid? AddressId { get; set; }


    }
}
