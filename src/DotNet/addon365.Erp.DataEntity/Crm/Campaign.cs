using System.Collections.Generic;

namespace addon365.Database.Entity.Crm
{
    public class Campaign : BaseEntityWithLogFields
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Filter { get; set; }

        public IList<CampaignInfo> Infos { get; set; }
    }
}
