using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Chit.DomainEntity
{
    public class PrivilageValues:addon365.Common.DomainEntity.PrivilageValues
    {
        public List<Privilage> MyProperty 
        { 
            get 
            {
                List<Privilage> lst = new List<Privilage>();
                lst.Add(new Privilage { Source = "addon365.Chit.DomainEntity.Feature", PropertyName = "Agent", DefaultValue = "true", AvailableValues = new string[2] { "true", "false" }});
                return lst;
            } 
        }
    }
}
