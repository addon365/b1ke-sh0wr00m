using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using addon365.Database.Entity.Employees;
namespace addon365.Database.Entity.Crm
{
    public class Appointment : BaseEntityWithLogFields
    {
        public Guid CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public BusinessCustomer Customer { get; set; }

        public string Description { get; set; }
        public DateTime AppiontmentDate { get; set; }

        public Guid AssignedToId { get; set; }

        public Guid CurrentStatusId { get; set; }

        public ICollection<AppointmentStatus> AppointmentStatuses { get; set; }

        
    }
}
