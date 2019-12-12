using System;

namespace addon365.Database.Entity.Admin.Menu
{
    public class MenuPackageTemplateChild : BaseEntityWithLogFields
    {
        public Guid MenuPackageTemplateMasterId { get; set; }
        public Guid MenuMasterId { get; set; }
        public string[] DefaultMenuGroup { get; set; }
        public string DefaultShorcut { get; set; }
    }
}
