using addon365.Database.Entity.Crm.Address;
using addon365.Database.Entity.Employees;
using addon365.Database.Entity.Permission;
using addon365.Database.Entity.Users;
using addon365.IService;
using addon365.IService.Crm;
using addon365.IService.Crm.Address;
using addon365.IService.Permission;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace addon365.Web.API.Controllers.CRM
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<Employee>
    {
        private IEmployeeService _employeeService;
        private IUserService _userService;
        private IHostingEnvironment hostingEnvironment;
        private IRoleGroupService _roleService;
        public EmployeesController(IEmployeeService employeeService,
            IUserService userService,
            IRoleGroupService roleService,
            IHostingEnvironment hostingEnvironment
            )
            : base(employeeService)
        {
            this._roleService = roleService;
            this._employeeService = employeeService;
            this._userService = userService;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpPost("excel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public IActionResult UploadCustomersAsExcel(IFormFile file)
        {
            if (file == null)
                return BadRequest("No file attached.");

            MemoryStream memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);
            int count = 0;
            int totalRows = 0;
            try
            {
                BulkSave(memoryStream, out count, out totalRows);
            }
            catch (Exception e)
            {
                return Json(
                    string.Format("{0} Items inserted out of {1} and caused error {2}",
                    count, totalRows, e.Message));
            }


            return Json(string.Format("{0} Items inserted out of {1}", count, totalRows));
        }

        private bool BulkSave(MemoryStream stream, out int count, out int total)
        {
            count = 0;
            var roles = _roleService.FindAll();
            var rolDict = new Dictionary<string, RoleGroupMaster>();
            foreach (RoleGroupMaster role in roles)
            {
                rolDict.Add(role.Name, role);
            }
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                total = reader.RowCount - 1;
                reader.Read();

                while (reader.Read())
                {
                    string userId = reader.GetString(0);
                    string password = reader.GetString(1);
                    string userName = reader.GetString(2);

                    string address1 = reader.GetString(3);
                    string address2 = reader.GetString(4);
                    long pinOrZip = (long)reader.GetDouble(5);
                    string village = reader.GetString(6);
                    string subDistrict = reader.GetString(7);
                    string mobileNumber = reader.GetDouble(8).ToString();
                    string roleGroup = reader.GetString(9);
                    User user = new User();
                    user.UserId = userId;
                    user.UserName = userName;
                    user.Password = password;

                    User foundUser = _userService.FindUser(userId);
                    if (foundUser != null)
                    {
                        continue;
                    }
                    Employee foundEmployee = _employeeService.FindByMobile(mobileNumber);
                    if (foundEmployee != null)
                        continue;

                    if (string.IsNullOrEmpty(roleGroup)
                        || !rolDict.ContainsKey(roleGroup))
                        continue;

                    user.RoleGroup = null;
                    user.RoleGroupId = rolDict[roleGroup].Id;

                    user = _userService.InsertUser(user);
                    Employee employee = new Employee();

                    employee.UserId = user.Id;
                    employee.Profile = new Database.Entity.Crm.Contact
                    {

                        ContactAddress = new Database.Entity.Crm.Address.Master
                        {
                            AddressLine1 = address1,
                            AddressLine2 = address2,
                            LocalityOrVillage = village,
                            PinOrZip = pinOrZip,
                            SubDistrict = subDistrict,

                        },
                        MobileNumber = mobileNumber
                    };
                    employee = baseService.Save(employee);
                    if (employee == null)
                        continue;

                    count++;
                }
            }
            return true;
        }


        [HttpGet("template")]
        public IActionResult GetTemplate()
        {
            String path = Path.Combine(hostingEnvironment.ContentRootPath
                , "Resources\\EmployeeTemplate.xlsx");
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        "EmployeeEntryTemplate.xlsx");

        }

    }
}