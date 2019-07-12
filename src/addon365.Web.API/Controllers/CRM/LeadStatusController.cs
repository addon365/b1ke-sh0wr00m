using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using addon365.Database.Entity.Crm;
using addon365.IService.Crm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace addon365.Web.API.Controllers.CRM
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadStatusController : BaseController<LeadStatusMaster>
    {
        public LeadStatusController(ILeadStatusService service) 
            : base(service)
        {

        }
    }
}