using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Database.Entity.Crm.Address
{

    public class Master : BaseEntityWithLogFields
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public long PinOrZip { get; set; }

        public Guid? LocalityOrVillageId { get; set; }
        public Guid? SubDistrictId { get; set; }
        public Guid? DistrictId { get; set; }
        public Guid? StateId { get; set; }
        public Guid? CountryId { get; set; }

    }
}
