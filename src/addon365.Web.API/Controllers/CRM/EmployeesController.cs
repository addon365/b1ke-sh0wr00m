using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using addon365.Database.Entity.Employees;
using addon365.IService.Crm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace addon365.Web.API.Controllers.CRM
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<Employee>
    {
        private IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
            : base(employeeService)
        {
            this._employeeService = employeeService;
        }
        
    }
}