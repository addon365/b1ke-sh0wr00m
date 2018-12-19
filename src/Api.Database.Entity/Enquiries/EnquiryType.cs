using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Database.Entity.Enquiries
{
    public class EnquiryType : BaseEntity
    {
        
        [Required]
        [StringLength(50)]
        public string Name
        {
            get;
            set;
        }
        public int ProgrammerId { get; set; }

        //public List<Enquiry> Enquiries { get; set; }
    }
}
