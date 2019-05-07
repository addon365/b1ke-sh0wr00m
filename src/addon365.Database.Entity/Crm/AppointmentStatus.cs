using System;

namespace addon365.Database.Entity.Crm
{
    public class AppointmentStatus : BaseEntity
    {
        public Appointment CurrentAppointment { get; set; }
        public StatusMaster Status { get; set; }
        public string Comments { get; set; }
        public DateTime UpdatedDate { get; set; }
        
    }
}
