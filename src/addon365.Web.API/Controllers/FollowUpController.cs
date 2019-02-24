using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using addon365.Database.Entity.Crm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using addon365.Database.Service.Crm;
using addon365.Web.API.Utils;

namespace addon365.Web.API.Controllers
{

    [Produces("application/json")]
    [Route("api/{license:license}/v{version:apiVersion}/[controller]")]
    public class FollowUpController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly ILogger _logger;
        private readonly IFollowUpService _followUpService;

        public FollowUpController(IFollowUpService followUpService,
            IOptions<AppSettings> appSettings,
            ILogger<FollowUpController> logger)
        {
            this._appSettings = appSettings.Value;
            this._followUpService = followUpService;
            this._logger = logger;
        }

        [HttpGet("followupstatuses")]
        public IActionResult GetFollowUpStatuses()
        {
            _logger.LogInformation("Fetching Follow up Statuses");
            return Ok(_followUpService.GetFollowUpStatuses());
        }

        [HttpGet("followupmodes")]
        public IActionResult GetFollowUpModes()
        {
            _logger.LogInformation("Fetching Follow up Modes");
            return Ok(_followUpService.GetFollowUpModes());
        }

        [HttpGet("campaign/{contactId}")]
        public IActionResult GetCampaignInfos(string contactId)
        {
            _logger.LogInformation("Fetching All Campaing Infos.");
            return Ok(_followUpService.GetCampaingInfos(contactId));
        }
        [HttpGet("contact/{contactId}")]
        public IActionResult GetContact(string contactId)
        {
            _logger.LogInformation("Fetching a Contact.");
            return Ok(_followUpService.GetContact(contactId));
        }

        [HttpPost]
        public IActionResult Insert([FromBody] CampaignInfo campaignInfo)
        {
            _logger.LogInformation("Inserting campaignInfo");
            return Ok(_followUpService.Insert(campaignInfo));
        }
    }
}