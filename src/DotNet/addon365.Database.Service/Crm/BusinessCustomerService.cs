using addon365.Database.Entity.Crm;
using addon365.Database.Service.Base;
using addon365.IService.Crm;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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


        public override BusinessCustomer Save(BusinessCustomer obj)
        {
            if (FindByMobile(obj.Contact.MobileNumber,
                obj.Contact.Landline) != null)
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

        public BusinessCustomer FindByMobile(string mobileNumber, string landLine)
        {
            var list = Repository.GetList(predicate:
                            c => c.Contact.MobileNumber.CompareTo(mobileNumber) == 0
                            || c.Contact.Landline.CompareTo(landLine) == 0,
                            include: x => x.Include(bc => bc.Contact));
            if (list.Count > 0)
                return list.Items[0];
            return null;
        }
    }
}
