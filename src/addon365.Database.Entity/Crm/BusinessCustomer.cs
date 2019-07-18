using addon365.Database.Entity.Users;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Crm
{
    public class BusinessCustomer : BaseEntityWithLogFields
    {
        public string Identifier { get; set; }
        public BusinessContact Contact { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
