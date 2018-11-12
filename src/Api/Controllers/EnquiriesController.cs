﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Bots;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swc.Service;
using Swashbuckle.AspNetCore;
using Api.Domain.Enquiries;
using Api.Database.Entity.Enquiries;
using Microsoft.AspNetCore.Authorization;

namespace swcApi.Controllers
{
    /// <inheritdoc />
    [Produces("application/json")]
    [Route("api/{license:license}/v{version:apiVersion}/[controller]")]
    public class EnquiriesController : Controller
    {
        private readonly IEnquiriesService _enquiriesService;

        /// <inheritdoc />
        public EnquiriesController(IEnquiriesService enquiriesService)
        {
            _enquiriesService = enquiriesService;
        }

        /// <summary>
        ///  Returns a list of all active referrer spammers
        /// </summary>
        ///<remarks>
        ///</remarks>
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<Enquiries> Get()
        {
            return _enquiriesService.GetAllActive();
        }

        [AllowAnonymous]
        [Route("InitilizeEnquiries")]
        [HttpGet]
        public InitilizeEnquiry GetInitilizeEnquiries()
        {
            return _enquiriesService.GetInitilizeEnquiries();
        }
        /// <summary>
        ///  Returns a collection of values
        /// </summary>
        ///<remarks>
        /// This is a remark to add additional information about this method
        ///</remarks>
        [HttpPost]
        public IActionResult Post([FromBody] InsertEnquiryModel referrer)
        {
            
                if (referrer == null)
            {
                return BadRequest();
            }
           
           var identifier = _enquiriesService.Insert(referrer);


            return Ok() ;
        }

        /// <summary>
        ///  Returns Details of a selected Referrer
        /// </summary>
        ///<remarks>
        ///
        ///</remarks>
        [HttpGet]
        [Route("Multi/{identifier}", Name = "EnquiriesMultiDetail")]
        public IActionResult MultiDetail(string identifier)
        {
            var referer = _enquiriesService.GetMultiEnquiries(identifier);
            if (referer == null) return NotFound();

            return Ok(referer);
        }
        [HttpGet]
        [Route("{identifier}", Name = "EnquiriesDetail")]
        public IActionResult Detail(string identifier)
        {
            var referer = _enquiriesService.GetEnquiries(identifier);
            if (referer == null) return NotFound();

            return Ok(referer);
        }
    }
}