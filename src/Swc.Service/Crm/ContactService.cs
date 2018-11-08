using System.Collections.Generic;
using Api.Database.Entity.Crm;
using Threenine.Data;

namespace Swc.Service.Crm
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Contact> GetContacts()
        {
            return _unitOfWork.GetRepository<Contact>().GetList().Items;
        }
    }
}
