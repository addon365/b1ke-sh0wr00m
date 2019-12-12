using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Crm
{
    public class Lead : BaseEntityWithLogFields
    {
        public string Identifier { get; set; }
        public BusinessContact Contact { get; set; }
        public Guid SourceId { get; set; }

        [ForeignKey("SourceId")]
        public LeadSource Source { get; set; }

        public Guid CurrentLeadStatusId { get; set; }

        public IList<LeadStatusHistory> History { get; set; }
    }
}
