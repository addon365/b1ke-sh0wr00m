using addon365.Database.Entity.Crm;
using System.Collections.Generic;

namespace addon365.IService.Crm
{
    public interface IContactService
    {
        IEnumerable<Contact> GetContacts();
    }
}
