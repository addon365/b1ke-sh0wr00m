using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Domain.Entity.Crm
{
    public class CampaignViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Filter { get; set; }
        public int Count { get; set; }
    }
}
