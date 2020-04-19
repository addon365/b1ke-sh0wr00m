using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace addon365.Common.DataEntity.Privilage
{
    public class BusinessPrivilageTable:BaseEntity
    {
        public string Source { get; set; }
        public string PropertyName { get; set; }
        public string CurrentValue { get; set; }
        public string DefaultValue { get; set; }
        public String ValueOptions { get; set; }

        [NotMapped]
        public List<String> Options
        {
            get { return ValueOptions.Split(',').ToList(); }
            set
            {
                ValueOptions = String.Join(",", value);
            }
        }
    }
}
