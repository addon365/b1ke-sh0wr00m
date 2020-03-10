using addon365.Database.Entity.Crm;
using addon365.Database.Entity.Crm.Address;
using addon365.Database.Entity.Users;
using addon365.IService;
using addon365.IService.Crm;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace addon365.Web.API.Controllers.CRM
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController<Customer>
    {
        ICustomerService service;
        IUserService userService;
        IWebHostEnvironment hostingEnvironment;
        public CustomersController(ICustomerService baseService,
            IUserService userService, IWebHostEnvironment hostingEnvironment)
            : base(baseService)
        {
            this.service = baseService;
            this.userService = userService;
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

            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                total = reader.RowCount - 1;
                reader.Read();
                while (reader.Read())
                {
                    string userId = reader.GetString(0);
                    string password = reader.GetString(1);
                    string userName = reader.GetString(2);
                    string businessName = reader.GetString(3);
                    string address1 = reader.GetString(4);
                    string address2 = reader.GetString(5);
                    long pinOrZip = (long)reader.GetDouble(6);
                    string village = reader.GetString(7);
                    string subDistrict = reader.GetString(8);
                    string mobileNumber = reader.GetDouble(9).ToString();
                    string landLine = reader.GetDouble(10).ToString();
                    User user = new User();
                    user.UserId = userId;
                    user.UserName = userName;
                    user.Password = password;

                    User foundUser = userService.FindUser(userId);
                    if (foundUser != null)
                    {
                        continue;
                    }
                    user = userService.InsertUser(user);
                    Customer customer = new Customer();

                    customer.UserId = user.Id;
                    customer.BusinessContact = new BusinessContact
                    {
                        BusinessName = businessName,
                        ContactAddress = new Database.Entity.Crm.Address.Master
                        {
                            AddressLine1 = address1,
                            AddressLine2 = address2,
                            LocalityOrVillage = village,
                            PinOrZip = pinOrZip,
                            SubDistrict = subDistrict,

                        },
                        MobileNumber = mobileNumber,
                        Landline = landLine

                    };
                    customer = baseService.Save(customer);
                    if (customer == null)
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
                , "Resources\\CustomerTemplate.xlsx");
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        "CustomerEntryTemplate.xlsx");

        }
    }
}