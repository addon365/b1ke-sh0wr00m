using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity
{
    public class DeviceMaster 
    {
        [Key]
        public UInt16 Id { get; set; }
        public string DeviceName { get; set; }
        public string DeviceId { get; set; }

       
    }
}
