
using addon365.Database.Entity.Employees;
using addon365.IService.Base;
using System.Collections.Generic;

namespace addon365.IService.Crm
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        Employee FindByMobile(string mobileNumber);
    }
}
