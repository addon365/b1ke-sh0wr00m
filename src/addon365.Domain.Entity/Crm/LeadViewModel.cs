using System;

namespace addon365.Domain.Entity.Crm
{
    public class LeadViewModel
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string StatusName { get; set; }

        public string ExtraData { get; set; }
    }
}
