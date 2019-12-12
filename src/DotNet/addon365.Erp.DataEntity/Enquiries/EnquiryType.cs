using System.ComponentModel.DataAnnotations;

namespace addon365.Database.Entity.Enquiries
{
    public class EnquiryType : BaseEntityWithLogFields
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
