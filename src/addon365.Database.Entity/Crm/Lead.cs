using addon365.Database.Entity.Users;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace addon365.Database.Entity.Crm
{
    public class Lead : BaseEntityWithLogFields
    {
        public string Identifier { get; set; }
        public BusinessContact Contact { get; set; }
        public Guid SourceId { get; set; }

        [ForeignKey("SourceId")]
        public LeadSource Source { get; set; }

        IList<AppointmentStatus> AppointmentStatuses { get; set; }
    }
}
