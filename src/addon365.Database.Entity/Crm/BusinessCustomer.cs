using System;


namespace addon365.Database.Entity.Crm
{
    public class BusinessCustomer : BaseEntityWithLogFields
    {
        public string Identifier { get; set; }
        public BusinessContact Contact{ get; set; }
        public Guid? UserId { get; set; }
    }
}
