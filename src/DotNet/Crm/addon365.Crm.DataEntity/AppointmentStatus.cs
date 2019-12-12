using addon365.Common.DataEntity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Crm.DataEntity
{
    public class AppointmentStatus : BaseEntityWithLogFields
    {
        public Guid StatusId { get; set; }
        [ForeignKey("StatusId")]
        public StatusMaster Status { get; set; }
        public string Comments { get; set; }
        public DateTime UpdatedDate { get; set; }

        public DateTime DueDate { get; set; }

        public Guid? AssignedToId { get; set; }

        [ForeignKey("AssignedToId")]
        public User AssignedTo { get; set; }

        public Guid? UpdatedById { get; set; }

        [ForeignKey("UpdatedById")]
        public User UpdatedBy { get; set; }

        public int Order { get; set; }

        public Guid AppointmentId { get; set; }

    }
}
