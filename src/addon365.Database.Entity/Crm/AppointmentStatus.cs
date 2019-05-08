using addon365.Database.Entity.Employees;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Crm
{
    public class AppointmentStatus : BaseEntityWithLogFields
    {
        public Guid StatusId { get; set; }
        [ForeignKey("StatusId")]
        public string Comments { get; set; }
        public DateTime UpdatedDate { get; set; }


        public Guid AppointmentId { get; set; }

        [ForeignKey("AppointmentId")]
        public Appointment CurrentAppointment { get; set; }

        public Guid AssignedToId { get; set; }

        public Guid UpdatedById { get; set; }

        [ForeignKey("UpdatedById")]
        public Employee UpdatedBy { get; set; } 
        

    }
}
