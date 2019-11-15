using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Accounts
{
    [Table("Accounts.AccountBooks")]
    public class AccountBook : BaseEntityWithLogFields
    {
        public string Identifier { get; set; }
        public string BookName { get; set; }
        public Guid UnderGroupId { get; set; }
        public string ProgrammerId { get; set; }


    }
    
}
