using addon365.Database.Entity.Users;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace addon365.Database.Entity.Crm
{
    public class Lead : BaseEntityWithLogFields
    {
        public string Identifier { get; set; }
        public BusinessContact Contact { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
