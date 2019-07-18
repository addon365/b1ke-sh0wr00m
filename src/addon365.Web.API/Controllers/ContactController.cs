using addon365.IService.Crm;
using addon365.Web.API.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace addon365.Web.API.Controllers
{
    [Produces("application/json")]
    [Route("api/{license:license}/v{version:apiVersion}/[controller]")]
    public class ContactController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly ILogger _logger;
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService,
            IOptions<AppSettings> appSettings,
            ILogger<UserController> logger)
        {
            this._appSettings = appSettings.Value;
            this._contactService = contactService;
            this._logger = logger;
        }

        [HttpGet()]
        public IActionResult GetFollowUpModes()
        {
            _logger.LogInformation("Fetching Follow up Modes");
            return Ok(_contactService.GetContacts());
        }
    }
}