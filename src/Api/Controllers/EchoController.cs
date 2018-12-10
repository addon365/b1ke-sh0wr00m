using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace swcApi.Controllers
{
    /// <summary>
    /// Echo Contollers is to test the server running status.
    /// </summary>
    [Produces("application/json")]
    [Route("api/{license:license}/v{version:apiVersion}/[controller]")]
    public class EchoController : Controller
    {
        private readonly ILogger _logger;

        public EchoController(ILogger<EchoController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Just return welcome message without any authentication.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult SayWelcome()
        {
            _logger.LogInformation("Invoking Say Welcome API");
            
            return Ok("Hi, Addon Technology Bikeshow showroom service is up and running:"+ this.RouteData.Values["license"].ToString());
        }

        [HttpGet("authorized")]
        [Authorize]
        public IActionResult Authorized()
        {
            _logger.LogInformation("Invoking Authorized API");
            return Ok("Hello, I am Authorized User");
        }
    }
}