using addon365.Common.DataEntity;
using addon365.Crm.DataEntity.Address;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Crm.DataEntity
{
    [Table("Crm.BusinessContacts")]
    public class BusinessContactTable : BaseEntityWithLogFields
    {
        public string BusinessName { get; set; }
        public string BusinessMailId { get; set; }
        public AddressTable ContactAddress { get; set; }
        public ContactTable Proprietor { get; set; }
        public ContactTable ContactPerson { get; set; }
        public string Landline { get; set; }
        public string MobileNumber { get; set; }
        public string SecondaryMobileNo { get; set; }
    }
}
