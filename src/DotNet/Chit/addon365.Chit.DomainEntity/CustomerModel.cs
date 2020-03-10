using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Chit.DomainEntity
{
    public class CustomerModel
    {
        public Guid KeyId { get; set; }
        public string AccessId { get; set; }
        public Guid? ContactKeyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string Place { get; set; }
        public string Address { get; set; }
    }
}
