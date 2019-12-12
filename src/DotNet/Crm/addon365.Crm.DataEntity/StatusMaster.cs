using addon365.Common.DataEntity;

namespace addon365.Crm.DataEntity
{
    public class StatusMaster : BaseEntityWithLogFields
    {
        public string StatusName { get; set; }
        public string Description { get; set; }
        public string ProgrammerId { get; set; }

        /**
         * Stores Majar || Minor as Value.
         */
        public string Priority { get; set; }
    }
}
