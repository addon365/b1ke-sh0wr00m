using addon365.Database.Entity.Employees;
using addon365.Database.Service.Base;
using addon365.IService.Crm;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Threenine.Data;

namespace addon365.Database.Service.Crm
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        public EmployeeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public Employee Save(Employee obj)
        {
            if (FindByMobile(obj.Profile.MobileNumber)!=null)
                return null;

            Repository.Add(obj);
            UnitOfWork.SaveChanges();
            return obj;
        }
        public override IEnumerable<Employee> FindAll()
        {
            return Repository.GetList(
                include: item => item.Include(x => x.User)
                .ThenInclude(u=>u.RoleGroup)
                .Include(c => c.Profile)
                .ThenInclude(ct => ct.ContactAddress)
                ).Items;
        }

        public Employee FindByMobile(string mobileNumber)
        {
            var list = Repository.GetList(predicate:
                            c => c.Profile.MobileNumber.CompareTo(mobileNumber) == 0,
                            include: x => x.Include(bc => bc.Profile));
            if (list.Count > 0)
                return list.Items[0];
            return null;
        }
    }
}
