using System;
using System.ComponentModel.DataAnnotations;

namespace addon365.Common.DataEntity
{
    public class BaseEntity
    {
        [Key]
        public Guid KeyId { get; set; }
        public BaseEntity()
        {
            this.KeyId = Guid.NewGuid();
        }

    }
}
