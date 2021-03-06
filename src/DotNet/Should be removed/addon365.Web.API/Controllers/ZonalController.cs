﻿using addon365.Database.Entity;
using addon365.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace addon365.Web.API.Controllers
{
    [Produces("application/json")]
    [Route("api/{license:license}/v{version:apiVersion}/[controller]")]
    public class ZonalController : Controller
    {
        private readonly IZonalService _zonalService;
        public ZonalController(IZonalService zonalService)
        {
            _zonalService = zonalService;
        }
        [HttpGet]
        public IEnumerable<MarketingZone> Get()
        {
            return _zonalService.GetAllActive();
        }

        [HttpPost]
        public IActionResult ZonalPost([FromBody] MarketingZone referrer)
        {
            if (referrer == null)
            {
                return BadRequest();
            }

            var identifier = _zonalService.Insert(referrer);


            return Ok();
        }

        [HttpGet]
        [Route("{identifier}", Name = "ZonalDetail")]
        public IActionResult Detail(string identifier)
        {
            var referer = _zonalService.GetReferer(identifier);
            if (referer == null) return NotFound();

            return Ok(referer);
        }

        [AllowAnonymous]
        [Route("Delete")]
        [HttpPost]
        public IActionResult Delete([FromBody] MarketingZone marketingZone)
        {
            if (marketingZone == null)
            {
                return BadRequest();
            }

            _zonalService.Delete(marketingZone);


            return Ok();
        }
    }
}
