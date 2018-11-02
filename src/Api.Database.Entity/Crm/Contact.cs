namespace Api.Database.Entity.Crm
{
    public class Contact : BaseEntity
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string Place { get; set; }
        public string Address { get; set; }
    }
}
