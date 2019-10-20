using addon365.Database.Entity.Crm;
using addon365.Database.Entity.Crm.Address;
using addon365.IService;
using addon365.IService.Crm;
using addon365.Database.Entity.Crm.Address;
using addon365.IService.Crm.Address;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace addon365.Web.API.Controllers.CRM
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : BaseController<Lead>
    {
        readonly ILeadService service;
        readonly IUserService userService;
        readonly ILeadSourceService sourceService;
        readonly ILeadStatusService leadStatusService;
        readonly IWebHostEnvironment hostingEnvironment;
        readonly IPincodeService pincodeService;
        readonly ISubDistrictService subDistrictService;
        readonly ILocalityService localityService;
        public LeadsController(ILeadService baseService,
            IUserService userService,
            ILeadSourceService sourceService,
            ILeadStatusService leadStatusService,
            IWebHostEnvironment hostingEnvironment,
            IPincodeService pincodeService,
            ISubDistrictService subDistrictService,
            ILocalityService localityService)
            : base(baseService)
        {
            this.service = baseService;
            this.userService = userService;
            this.sourceService = sourceService;
            this.leadStatusService = leadStatusService;
            this.hostingEnvironment = hostingEnvironment;
            this.pincodeService = pincodeService;
            this.subDistrictService = subDistrictService;
            this.localityService = localityService;
        }

        [HttpGet("followup")]
        public IActionResult GetNecessaryLeads()
        {
            return Ok(service.FindLeads());
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
        private IDictionary<string, LeadSource> GetLeadSourceDict()
        {
            IDictionary<string, LeadSource> keyValues =
                new Dictionary<string, LeadSource>();
            foreach (LeadSource source in sourceService.FindAll())
            {
                keyValues.Add(source.Name, source);
            }
            return keyValues;
        }
        private IDictionary<long, PincodeMaster> GetPincodeDict()
        {
            IDictionary<long, PincodeMaster> keyValues =
                new Dictionary<long, PincodeMaster>();
            foreach (PincodeMaster source in pincodeService.FindAll())
            {
                keyValues.Add(source.Pincode, source);
            }
            return keyValues;
        }
        private IDictionary<string, LocalityOrVillageMaster> GetLocalityDict()
        {
            IDictionary<string, LocalityOrVillageMaster> keyValues =
                new Dictionary<string, LocalityOrVillageMaster>();
            foreach (LocalityOrVillageMaster source in localityService.FindAll())
            {
                keyValues.Add(source.LocalityOrVillageName, source);
            }
            return keyValues;
        }
        private IDictionary<string, SubDistrictMaster> GetSubDistDict()
        {
            IDictionary<string, SubDistrictMaster> keyValues =
                new Dictionary<string, SubDistrictMaster>();
            foreach (SubDistrictMaster source in subDistrictService.FindAll())
            {
                keyValues.Add(source.SubDistrictName, source);
            }
            return keyValues;
        }
        private bool BulkSave(MemoryStream stream, out int count, out int total)
        {
            count = 0;
            var leadSourcesDict = GetLeadSourceDict();
            var pincodeDict = GetPincodeDict();
            var subDistDict = GetSubDistDict();
            var localityDic = GetLocalityDict();

            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                total = reader.RowCount - 1;
                reader.Read();
                int index = 0;
                while (reader.Read())
                {
                    string businessName = reader.GetString(index++);

                    string proprietorName = reader.GetString(index++);
                    string proprietorMobile = reader.GetDouble(index++).ToString();

                    string communicatorName = reader.GetString(index++);
                    string communicatorMobile = reader.GetDouble(index++).ToString();

                    string address1 = reader.GetString(index++);
                    string address2 = reader.GetString(index++);
                    long pinOrZip = (long)reader.GetDouble(index++);
                    Guid? pinOrZipId = pincodeDict.ContainsKey(pinOrZip) ? (Guid?)pincodeDict[pinOrZip].Id : null;

                    string village = reader.GetString(index++);

                    Guid? villageId = localityDic.ContainsKey(village) ? (Guid?)localityDic[village].Id : null;

                    string subDistrict = reader.GetString(index++);
                    Guid? subDistrictId = subDistDict.ContainsKey(subDistrict) ? (Guid?)subDistDict[subDistrict].Id : null;

                    string mobileNumber = reader.GetDouble(index++).ToString();
                    string landLine = reader.GetDouble(index++).ToString();
                    string leadSourceName = reader.GetString(index++);

                    /**
                     * Need to reset the column index to zero
                     */
                    index = 0;

                    LeadSource leadSource = null;
                    if (leadSourcesDict.ContainsKey(leadSourceName))
                    {
                        leadSource = leadSourcesDict[leadSourceName];
                    }

                    Lead foundLead = this.service
                        .FindByMobile(mobileNumber, landLine);
                    if (foundLead != null)
                    {
                        continue;
                    }

                    var leadOpenStatus = leadStatusService.FindByName("Open");

                    Contact proprietorcontact = null;
                    if (proprietorName != null && proprietorMobile != null
                        && proprietorMobile.Length >= 10)
                    {
                        proprietorcontact = new Contact
                        {
                            Id = Guid.NewGuid(),
                            FirstName = proprietorName,
                            MobileNumber = proprietorMobile
                        };
                    }
                    Contact communicatorContact = null;
                    if (communicatorName != null && communicatorMobile != null
                        && communicatorMobile.Length >= 10)
                    {
                        communicatorContact = new Contact
                        {
                            Id = Guid.NewGuid(),
                            FirstName = communicatorName,
                            MobileNumber = communicatorMobile
                        };
                    }
                    var history = new LeadStatusHistory
                    {
                        StatusDate = DateTime.Now,
                        Status = null,
                        StatusId = leadOpenStatus.Id,
                        Created = DateTime.Now,
                        Order = 0,
                    };
                    Lead lead = new Lead
                    {
                        SourceId = leadSource.Id,
                        Source = null,
                        History = new List<LeadStatusHistory>()
                            {
                                history
                            },
                        CurrentLeadStatusId = history.Id
                    };

                    lead.Contact = new BusinessContact
                    {
                        BusinessName = businessName,
                        ContactAddress = new Database.Entity.Crm.Address.Master
                        {
                            AddressLine1 = address1,
                            AddressLine2 = address2,
                            LocalityOrVillage = village,
                            LocalityOrVillageId = villageId,
                            PinOrZip = pinOrZip,

                            SubDistrict = subDistrict,
                            SubDistrictId = subDistrictId

                        },
                        Proprietor = proprietorcontact,
                        ContactPerson = communicatorContact,
                        MobileNumber = mobileNumber,
                        Landline = landLine,

                    };
                    lead = baseService.Save(lead);
                    if (lead == null)
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
                , "Resources\\LeadTemplate.xlsx");
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        "LeadsEntryTemplate.xlsx");

        }

        [HttpPut("status")]
        public IActionResult UpdateStatus([FromBody] Lead lead)
        {
            return Ok(service.Update(lead.Id, lead));
        }
    }
}