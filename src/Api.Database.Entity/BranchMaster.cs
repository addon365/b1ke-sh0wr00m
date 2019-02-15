using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity
{
    public class BranchMaster:BaseEntity
    {
       
        public string BranchName { get; set; }
        public string ShortCode { get; set; }
        public string Location { get; set; }
        public Guid LicenseId { get; set; }
       
    }
}
