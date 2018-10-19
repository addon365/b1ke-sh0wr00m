using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity
{
    public class LicenseMaster 
    {
        [Key]
        public Guid Id { get; set; }
        public string BusinessName { get; set; }
        public string LicenseId { get; set; }
        public string Location { get; set; }
        public int ProgrammerID { get; set; }
        public LicenseMaster()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
