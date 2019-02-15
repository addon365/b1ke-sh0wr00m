using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Database.Entity.Enquiries
{
    public class EnquiryStatus : BaseEntityWithLogFields
    {
      
        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [StringLength(255)]
        public string  Description { get; set; }

        public int ProgrammerId { get; set; }

       // public virtual ICollection<Enquiry> Enquiries { get; set; }
    }
}
