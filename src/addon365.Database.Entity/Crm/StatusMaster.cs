namespace addon365.Database.Entity.Crm
{
    public class StatusMaster : BaseEntityWithLogFields
    {
        public string StatusName { get; set; }
        public string Description { get; set; }
        public string ProgrammerId { get; set; }
    }
}
