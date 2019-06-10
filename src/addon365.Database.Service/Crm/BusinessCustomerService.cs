using addon365.Database.Entity.Crm;
using addon365.Database.Entity.Users;
using addon365.Database.Service.Base;
using addon365.IService.Crm;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using Threenine.Data;

namespace addon365.Database.Service.Crm
{
    public class BusinessCustomerService : BaseService<BusinessCustomer>,
        IBusinessCustomerService
    {
        public BusinessCustomerService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }


        public BusinessCustomer Save(BusinessCustomer obj)
        {
            var list = Repository.GetList(predicate:
                c => c.Contact.MobileNumber.CompareTo(obj.Contact.MobileNumber) == 0
                || c.Contact.Landline.CompareTo(obj.Contact.Landline) == 0,
                include: x => x.Include(bc => bc.Contact));
            if (list.Count > 0)
                return null;

            Repository.Add(obj);
            UnitOfWork.SaveChanges();
            return obj;
        }
        public override IEnumerable<BusinessCustomer> FindAll()
        {
            return Repository.GetList(
                include: item => item.Include(x => x.User)
                .Include(c => c.Contact)
                .ThenInclude(ct => ct.ContactAddress)
                ).Items;
        }
    }
}
