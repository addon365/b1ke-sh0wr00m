using addon365.Database.Entity.Employees;
using addon365.Database.Service.Base;
using addon365.IService.Crm;
using Threenine.Data;

namespace addon365.Database.Service.Crm
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        public EmployeeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
