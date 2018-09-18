using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity
{
    public class Profile:BaseEntity
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string Place { get; set; }
        public string Address { get; set; }
    }
}
