using System;

namespace Api.Database.Entity.Crm
{
    public class Contact : BaseEntityWithLogFields
    {
        public string Identifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Place { get; set; }
        public string Address { get; set; }
        public Guid? AddressId { get; set; }

      
    }
}
