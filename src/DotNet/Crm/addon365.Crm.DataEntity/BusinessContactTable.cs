using addon365.Common.DataEntity;

namespace addon365.Crm.DataEntity
{
    public class BusinessContactTable : BaseEntityWithLogFields
    {
        public string BusinessName { get; set; }
        public string BusinessMailId { get; set; }
        public Address.Master ContactAddress { get; set; }
        public ContactTable Proprietor { get; set; }
        public ContactTable ContactPerson { get; set; }
        public string Landline { get; set; }
        public string MobileNumber { get; set; }
        public string SecondaryMobileNo { get; set; }
    }
}
