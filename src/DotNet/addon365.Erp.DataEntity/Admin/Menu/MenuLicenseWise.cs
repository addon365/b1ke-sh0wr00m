using System;

namespace addon365.Database.Entity.Admin.Menu
{
    public class MenuLicenseWise : BaseEntityWithLogFields
    {
        public Guid LicenseMasterId { get; set; }
        public Guid MenuMasterId { get; set; }
    }
}
