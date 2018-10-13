using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace swcApi.Controllers
{
    /// <summary>
    /// Echo Contollers is to test the server running status.
    /// </summary>
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/Echo")]
    public class EchoController : Controller
    {
        /// <summary>
        /// Just return welcome message without any authentication.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult SayWelcome()
        {
            return Ok("Hi, Addon Technology Bikeshow showroom service is up and running.");
        }

        [HttpGet("authorized")]
        [Authorize]
        public IActionResult authorized()
        {
            return Ok("Hello, I am Authorized User");
        }
    }
}