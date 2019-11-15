using addon365.Database.Entity.Crm;
using addon365.Database.Service.Base;
using addon365.IService.Crm;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Threenine.Data;

namespace addon365.Database.Service.Crm
{
    public class CustomerService : BaseService<Customer>,
        ICustomerService
    {
        public CustomerService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }


        public override Customer Save(Customer obj)
        {
            if (FindByMobile(obj.Contact.MobileNumber,
                obj.BusinessContact.Landline) != null)
                return null;

            Repository.Add(obj);
            UnitOfWork.SaveChanges();
            return obj;
        }
        public override IEnumerable<Customer> FindAll()
        {
            return Repository.GetList(
                include: item => item.Include(x => x.User)
                .Include(c => c.Contact)
                .ThenInclude(ct => ct.ContactAddress)
                ).Items;
        }

        public Customer FindByMobile(string mobileNumber, string landLine)
        {
            var list = Repository.GetList(predicate:
                            c => c.BusinessContact.MobileNumber.CompareTo(mobileNumber) == 0
                            || c.BusinessContact.Landline.CompareTo(landLine) == 0,
                            include: x => x.Include(bc => bc.BusinessContact));
            if (list.Count > 0)
                return list.Items[0];
            return null;
        }
    }
}
