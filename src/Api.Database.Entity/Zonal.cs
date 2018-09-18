using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity
{
    public class Zonal:BaseEntity
    {
        public string Identifier { get; set; }
        public string ZonalName { get; set; }
        public string ZonalDescription { get; set; }
    }
}
