using addon365.Common.DataEntity;

namespace addon365.Database.Entity
{
    public class MarketingZone : BaseEntityWithLogFields
    {
        public string Identifier { get; set; }
        public string ZonalName { get; set; }
        public string ZonalDescription { get; set; }
    }
}
