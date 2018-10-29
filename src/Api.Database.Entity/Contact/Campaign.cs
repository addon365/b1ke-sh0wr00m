using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity.Contact
{
    public class Campaign:BaseEntity
    {
        public string Name { get; set; }
        public string Filter { get; set; }
    }
}
