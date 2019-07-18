namespace addon365.Database.Entity.Crm
{
    public class CampaignInfo : BaseEntityWithLogFields
    {
        public Lead Lead { get; set; }

        public LeadStatusHistory CurrentStatus { get; set; }

        public bool IsInProgress { get; set; }



    }
}
