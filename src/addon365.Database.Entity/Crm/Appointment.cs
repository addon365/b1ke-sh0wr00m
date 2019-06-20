using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using addon365.Database.Entity.Utils;
using Newtonsoft.Json;

namespace addon365.Database.Entity.Crm
{
    public class Appointment : BaseEntityWithLogFields
    {
        public Guid LeadId{ get; set; }

        [ForeignKey("LeadId")]
        public Lead Lead { get; set; }


        public DateTime AppointmentDate { get; set; }

        public Guid CurrentStatusId { get; set; }

        [ForeignKey("CurrentStatusId")]
        public virtual AppointmentStatus CurrentStatus { get; set; }

    }
}
