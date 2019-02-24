﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using addon365.Domain.Entity.Bots;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using addon365.Database.Service;
using Swashbuckle.AspNetCore;

namespace addon365.Web.Api.Controllers
{
    /// <inheritdoc />
    [Produces("application/json")]
    [Route("api/{license:license}/v{version:apiVersion}/[controller]")]
    public class ReferrerController : Controller
    {
        private readonly IReferrerService _referrerService;

        /// <inheritdoc />
        public ReferrerController(IReferrerService referrerService)
        {
            _referrerService = referrerService;
        }

        /// <summary>
        ///  Returns a list of all active referrer spammers
        /// </summary>
        ///<remarks>
        ///</remarks>
        [HttpGet]
        public IEnumerable<Referrer> Get()
        {
            return _referrerService.GetAllActive();
        }


        /// <summary>
        ///  Returns a collection of values
        /// </summary>
        ///<remarks>
        /// This is a remark to add additional information about this method
        ///</remarks>
        [HttpPost]
        public IActionResult Post([FromBody] Referrer referrer)
        {
            if (referrer == null)
            {
                return BadRequest();
            }
           
           var identifier =  _referrerService.Insert(referrer);
            

            return CreatedAtRoute("Detail",new{ identifier} ,referrer);
        }

        /// <summary>
        ///  Returns Details of a selected Referrer
        /// </summary>
        ///<remarks>
        ///
        ///</remarks>
        [HttpGet]
        [Route("{identifier}", Name = "Detail")]
        public IActionResult Detail(string identifier)
        {
            var referer=  _referrerService.GetReferer(identifier);
            if (referer == null) return NotFound();

            return Ok(referer);
        }
    }
}