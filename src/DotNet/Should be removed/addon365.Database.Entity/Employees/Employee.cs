using addon365.Database.Entity.Crm;
using addon365.Database.Entity.Users;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace addon365.Database.Entity.Employees
{
    public class Employee : BaseEntityWithLogFields
    {
        public string Identifier { get; set; }
        public Guid ContactId { get; set; }
        [ForeignKey("ContactId")] public virtual Contact Profile { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime LastDate { get; set; }
        public Double Salary { get; set; }
        public Guid? DesignationId { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
