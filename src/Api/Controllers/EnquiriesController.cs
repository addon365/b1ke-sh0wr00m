using System;
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

namespace swcApi.Controllers
{
    /// <inheritdoc />
    [Produces("application/json")]
    [Route("api/[controller]")]
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
        [HttpGet]
        public InitilizeEnquiry Get()
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
            

            return CreatedAtRoute("EnquiriesDetail", new{ identifier} ,referrer);
        }

        /// <summary>
        ///  Returns Details of a selected Referrer
        /// </summary>
        ///<remarks>
        ///
        ///</remarks>
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