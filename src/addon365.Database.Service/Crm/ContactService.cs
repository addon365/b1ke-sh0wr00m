using System.Collections.Generic;
using addon365.Database.Entity.Crm;
using Threenine.Data;

namespace addon365.Database.Service.Crm
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
