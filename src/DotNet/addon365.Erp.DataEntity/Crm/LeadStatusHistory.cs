﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Crm
{
    public class LeadStatusHistory : BaseEntityWithLogFields
    {

        public DateTime StatusDate { get; set; }

        public Guid StatusId { get; set; }

        [ForeignKey("StatusId")]
        public LeadStatusMaster Status { get; set; }

        public string ExtraData { get; set; }

        public int Order { get; set; }
    }
}
