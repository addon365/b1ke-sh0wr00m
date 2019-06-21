using System;
using System.ComponentModel.DataAnnotations;

namespace addon365.Database.Entity.Report
{
    public class AppointmentReport
    {
        [Key]
        public Guid Id { get; set; }
        public string LeadName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        public string AssignedTo { get; set; }
        public string Comments { get; set; }
    }
}
