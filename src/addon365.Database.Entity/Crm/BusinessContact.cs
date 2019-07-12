using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Database.Entity.Crm
{
    public class BusinessContact:BaseEntityWithLogFields
    {
        public string BusinessName { get; set; }
        public AddressMaster ContactAddress { get; set; }
        public Contact Proprietor { get; set; }
        public Contact ContactPerson{ get; set; }
        public string Landline { get; set; }
        public string MobileNumber { get; set; }
        public string SecondaryMobileNo { get; set; }
    }
}
