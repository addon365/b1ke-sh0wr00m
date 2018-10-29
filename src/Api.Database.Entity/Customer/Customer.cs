using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Database.Entity.Employee
{
    public class Customer:BaseEntity
    {
        public string Identifier { get; set; }
        public Guid ProfileId { get; set; }
        [ForeignKey("ProfileId")] public virtual Contact Profile { get; set; }
      
        public Guid? UserId { get; set; }
    }
}
