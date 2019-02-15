﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity.Crm
{
    public class BusinessContact:BaseEntityWithLogFields
    {
        public string BusinessName { get; set; }
        public AddressMaster ContactAddress { get; set; }
        public string Landline { get; set; }
        public string MobileNumber { get; set; }
        public string SecondaryMobileNo { get; set; }
    }
}