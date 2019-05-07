using System;
using addon365.Database.Entity.Employees;
namespace addon365.Database.Entity.Crm
{
   public class Appointment:BaseEntityWithLogFields
    {
        public BusinessCustomer Customer { get; set; }
        public string Comments { get; set; }
        public DateTime AppiontmentDate { get; set; }
        public AppointmentStatus  CurrentStatus { get; set; }
        public Employee AssignedTo { get; set; }
    }
}
