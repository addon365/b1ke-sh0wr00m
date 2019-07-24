using addon365.Database.Entity.Crm;
using System;

namespace addon365.Domain.Entity.Crm
{
    public class LeadStatusViewModel
    {
        public Guid LeadId { get; set; }
        public LeadStatusMaster Status { get; set; }
        public string ExtraData { get; set; }

    }
}
