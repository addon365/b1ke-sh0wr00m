using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity
{
    public class DeviceMaster :BaseEntity
    {
        public string DeviceName { get; set; }
        public Guid? BranchId { get; set; }
    }
}
