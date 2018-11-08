using Api.Database.Entity.Crm;
using System.Collections.Generic;

namespace Swc.Service.Crm
{
    public interface IContactService
    {
        IEnumerable<Contact> GetContacts();
    }
}
