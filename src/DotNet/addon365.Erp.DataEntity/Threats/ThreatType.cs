using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace addon365.Database.Entity.Threats
{
    public class ThreatType : BaseEntityWithLogFields
    {
        public ThreatType()
        {

        }

        [Required]
        [StringLength(50)]
        public string Name
        {
            get;
            set;
        }

        public virtual ICollection<Threat> Threats { get; set; }
    }
}
