using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity
{
    public class BaseEntityWithLogFields:BaseEntity
    {
       
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }
        public int? CreatedUserId { get; set; }
        public int? CreatedDeviceId { get; set; }
        public Guid? BranchMasterId { get; set; }

       
    }
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public BaseEntity()
        {
            this.Id = Guid.NewGuid();
        }

    }
}
