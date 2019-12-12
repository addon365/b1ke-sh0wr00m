using addon365.Common.DataEntity;
using System;

namespace addon365.Crm.DataEntity.Address
{
    public class Master : BaseEntityWithLogFields
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public long PinOrZip { get; set; }
        public string LocalityOrVillage { get; set; }
        public Guid? LocalityOrVillageId { get; set; }
        public string SubDistrict { get; set; }
        public Guid? SubDistrictId { get; set; }
        public Guid? DistrictId { get; set; }
        public Guid? StateId { get; set; }
        public Guid? CountryId { get; set; }

    }
}
