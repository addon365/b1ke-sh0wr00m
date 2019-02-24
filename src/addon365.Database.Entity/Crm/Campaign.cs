using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Database.Entity.Crm
{
    public class Campaign:BaseEntityWithLogFields
    {
        public string Name { get; set; }
        public string Filter { get; set; }
    }
}
