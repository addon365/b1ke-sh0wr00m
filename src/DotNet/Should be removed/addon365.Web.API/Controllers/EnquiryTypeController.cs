﻿using addon365.Database.Entity.Enquiries;
using addon365.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace addon365.Web.API.Controllers
{
    [Produces("application/json")]
    [Route("api/{license:license}/v{version:apiVersion}/[controller]")]
    public class EnquiryTypeController : Controller
    {
        private readonly IEnquiryTypeService _enquirytypeService;
        public EnquiryTypeController(IEnquiryTypeService enquirytypeService)
        {
            _enquirytypeService = enquirytypeService;
        }
        [HttpGet]
        public IEnumerable<EnquiryType> Get()
        {
            return _enquirytypeService.GetAllEnquiryType();
        }

        [HttpPost]
        public IActionResult EnquiryTypePost([FromBody] EnquiryType referrer)
        {
            if (referrer == null)
            {
                return BadRequest();
            }

            var identifier = _enquirytypeService.Insert(referrer);


            return Ok();
        }

        [HttpGet]
        [Route("{identifier}", Name = "EnquiryTypeDetail")]
        public IActionResult Detail(int identifier)
        {
            var referer = _enquirytypeService.GetEnquiryType(identifier);
            if (referer == null) return NotFound();

            return Ok(referer);
        }

        [AllowAnonymous]
        [Route("Delete")]
        [HttpPost]
        public IActionResult Delete([FromBody] EnquiryType enquiryType)
        {
            if (enquiryType == null)
            {
                return BadRequest();
            }

            _enquirytypeService.Delete(enquiryType);


            return Ok();
        }
    }
}
