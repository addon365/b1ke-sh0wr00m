using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swc.Service.Crm;
using swcApi.Utils;

namespace swcApi.Controllers
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