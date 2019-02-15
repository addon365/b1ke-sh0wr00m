using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity
{
    public class DeviceMaster:BaseEntity 
    {
       
        public int OtherId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceId { get; set; }
        public string RequestedUser { get; set; }
        public string AuthorisedUser { get; set; }



    }
}
