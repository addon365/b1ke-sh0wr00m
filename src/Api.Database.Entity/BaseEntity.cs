using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity
{
    public class BaseEntity
    {
       
        [Key]
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }
        public UInt16? CreatedUserId { get; set; }
        public UInt16? CreatedDeviceId { get; set; }
        public UInt16? BranchMasterId { get; set; }

        public BaseEntity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
