using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using addon365.Database.Entity.Utils;
using Newtonsoft.Json;

namespace addon365.Database.Entity.Crm
{
    public class Appointment : BaseEntityWithLogFields
    {
        public Guid CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public BusinessCustomer Customer { get; set; }


        public DateTime AppointmentDate { get; set; }

        public Guid CurrentStatusId { get; set; }

        [ForeignKey("CurrentStatusId")]
        public AppointmentStatus CurrentStatus { get; set; }

    }
}
