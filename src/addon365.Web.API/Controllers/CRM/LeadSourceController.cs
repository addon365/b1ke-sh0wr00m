using addon365.Database.Entity.Crm;
using addon365.IService.Crm;
using Microsoft.AspNetCore.Mvc;

namespace addon365.Web.API.Controllers.CRM
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadSourceController : BaseController<LeadSource>
    {
        public LeadSourceController(ILeadSourceService service) : base(service)
        {

        }
    }
}