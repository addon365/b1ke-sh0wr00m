using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Domain.Entity.Crm
{
    public class AppointmentViewModel
    {
        public Guid Id { get; set; }
        public Guid LeadId { get; set; }
        public string LeadName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string PreviousStatus { get; set; }
        public Guid StatusId { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        public Guid? AssignedToId { get; set; }
        public string AssignedTo { get; set; }
        public string Comments { get; set; }

        public Guid? UpdatedById { get; set; }

        public string UpdatedBy { get; set; }

    }
}
