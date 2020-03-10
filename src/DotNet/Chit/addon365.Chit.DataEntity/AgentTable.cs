using addon365.Common.DataEntity;
using addon365.Crm.DataEntity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Chit.DataEntity
{
    [Table("Agency.Agent")]
    public class AgentTable:BaseEntity 
    {
        public string AccessId { get; set; }
        public Guid ContactId { get; set; }

        [ForeignKey("ContactId")]
        public ContactTable Contact { get; set; }
    }
}
