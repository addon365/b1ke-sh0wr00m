
using Api.Database.Entity.Enquiries;
using Api.Database.Entity.Crm;

namespace Reports
{
    public class Contact 
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string Place { get; set; }
        public string Address { get; set; }
    }
}
