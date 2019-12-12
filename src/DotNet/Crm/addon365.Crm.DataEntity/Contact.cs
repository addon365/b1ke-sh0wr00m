using addon365.Common.DataEntity;
using System;

namespace addon365.Crm.DataEntity
{
    public class Contact : BaseEntityWithLogFields
    {
        public string Identifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string SecondaryMobileNo { get; set; }
        public string Place { get; set; }
        public Address.Master ContactAddress { get; set; }
        public string Address { get; set; }
        public Guid? AddressId { get; set; }


    }
}
