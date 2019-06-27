﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using addon365.Database.Entity.Utils;
using Newtonsoft.Json;

namespace addon365.Database.Entity.Crm
{
    public class Appointment : BaseEntityWithLogFields
    {
        public Guid LeadId { get; set; }

        [ForeignKey("LeadId")]
        public Lead Lead { get; set; }

        public DateTime AppointmentDate { get; set; }

        public virtual List<AppointmentStatus> AppointmentStatuses { get; set; }

    }
}
