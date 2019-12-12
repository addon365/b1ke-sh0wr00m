﻿using addon365.Common.DataEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Crm.DataEntity
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
