﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity
{
    public class LicenseMaster:BaseEntity
    {
       
        public string BusinessName { get; set; }
        public string LicenseId { get; set; }
        public string Location { get; set; }
       
    }
}