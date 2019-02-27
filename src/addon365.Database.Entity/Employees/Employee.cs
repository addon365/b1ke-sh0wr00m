﻿using addon365.Database.Entity.Crm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace addon365.Database.Entity.Employee
{
    public class Employee:BaseEntityWithLogFields
    {
        public string Identifier { get; set; }
        public Guid ContactId { get; set; }
        [ForeignKey("ContactId")] public virtual Contact Profile { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime LastDate { get; set; }
        public Double Salary { get; set; }
        public Guid? DesignationId { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? UserId { get; set; }
    }
}