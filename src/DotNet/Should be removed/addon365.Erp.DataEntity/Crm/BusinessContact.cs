﻿namespace addon365.Database.Entity.Crm
{
    public class BusinessContact : BaseEntityWithLogFields
    {
        public string BusinessName { get; set; }
        public string BusinessMailId { get; set; }
        public Address.Master ContactAddress { get; set; }
        public Contact Proprietor { get; set; }
        public Contact ContactPerson { get; set; }
        public string Landline { get; set; }
        public string MobileNumber { get; set; }
        public string SecondaryMobileNo { get; set; }
    }
}
