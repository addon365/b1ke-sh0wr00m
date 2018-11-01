using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Database.Entity.Crm
{
    public class Customer : BaseEntity
    {
        public string Identifier { get; set; }
        public Guid ContactId { get; set; }
        [ForeignKey("ContactId")] public virtual Contact Profile { get; set; }

        public Guid? UserId { get; set; }
    }
}
