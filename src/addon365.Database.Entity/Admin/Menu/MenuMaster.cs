using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Database.Entity.Admin.Menu
{
    public class MenuMaster:BaseEntityWithLogFields
    {
        public string KeyName  { get; set; }
        public string Value { get; set; }
        public Guid UiTechMasterId { get; set; }
    }
}
