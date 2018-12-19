using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity
{
    public class BranchMaster 
    {
        [Key]
        public UInt16 Id { get; set; }
        public string BranchName { get; set; }
        public string ShortCode { get; set; }
        public string Location { get; set; }
        public UInt16 LicenseId { get; set; }
       
    }
}
