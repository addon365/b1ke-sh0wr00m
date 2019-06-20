using addon365.Database.Entity.Employees;
using addon365.Database.Entity.Users;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Crm
{
    public class AppointmentStatus : BaseEntityWithLogFields
    {
        public Guid StatusId { get; set; }
        [ForeignKey("StatusId")]
        public StatusMaster Status { get; set; }
        public string Comments { get; set; }
        public DateTime UpdatedDate { get; set; }

        public DateTime DueDate { get; set; }

        public Guid AppointmentId { get; set; }

        public Guid? AssignedToId { get; set; }

        [ForeignKey("AssignedToId")]
        public User AssignedTo { get; set; }

        public Guid? UpdatedById { get; set; }

        [ForeignKey("UpdatedById")]
        public User UpdatedBy { get; set; }


    }
}
