using System;
using System.ComponentModel.DataAnnotations;

namespace addon365.Common.DataEntity
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
