using System;
using System.ComponentModel.DataAnnotations;

namespace addon365.Database.Entity
{
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
