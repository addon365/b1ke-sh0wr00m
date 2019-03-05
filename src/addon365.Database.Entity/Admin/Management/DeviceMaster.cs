using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity
{
    public class DeviceMaster:BaseEntityWithLogFields
    {
       
        public int OtherId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceId { get; set; }
        public string MacId1 { get; set; }
        public string MacId2 { get; set; }

    }
}
