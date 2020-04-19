using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Chit.DomainEntity
{
    public class Privilage
    {
        public string Source { get; set; }
        public string PropertyName { get; set; }
        public string DefaultValue { get; set; }
        public String[] AvailableValues { get; set; }

    }
}
