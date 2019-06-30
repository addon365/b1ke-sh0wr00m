using addon365.Database.Entity.Crm;
using addon365.Database.Service.Base;
using addon365.IService.Crm;
using System.Collections.Generic;
using Threenine.Data;
using Microsoft.EntityFrameworkCore;
namespace addon365.Database.Service.Crm
{
    public class LeadService : BaseService<Lead>,
        ILeadService
    {
        public LeadService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }


        public Lead Save(Lead obj)
        {
            if (FindByMobile(obj.Contact.MobileNumber,
                obj.Contact.Landline) != null)
                return null;

            Repository.Add(obj);
            UnitOfWork.SaveChanges();
            return obj;
        }
        public override IEnumerable<Lead> FindAll()
        {
            return Repository.GetList(
                include: item => item.Include(c => c.Contact)
                .ThenInclude(ct => ct.ContactAddress)
                ).Items;
        }

        public Lead FindByMobile(string mobileNumber, string landline)
        {
            var list = Repository.GetList(predicate:
               c => c.Contact.MobileNumber.CompareTo(mobileNumber) == 0
               || c.Contact.Landline.CompareTo(landline) == 0,
               include: x => x.Include(bc => bc.Contact));
            if (list.Count>0)
                return list.Items[0];
            return null;
        }
    }
}
