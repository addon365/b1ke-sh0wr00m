﻿using addon365.Database.Entity.Enquiries;
using addon365.Database.Service;
using addon365.Domain.Entity.Enquiries;
using addon365.Domain.Entity.Paging;
using addon365.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace addon365.Web.API.Controllers
{
    /// <inheritdoc />
    [Produces("application/json")]
    [Route("api/{license:license}/v{version:apiVersion}/[controller]")]
    public class EnquiriesController : Controller
    {
        private readonly IEnquiriesService _enquiriesService;
        private RequestInfo _reqinfo;
        private readonly ILogger _logger;
        /// <inheritdoc />
        public EnquiriesController(IEnquiriesService enquiriesService, RequestInfo r, ILogger<EnquiriesController> logger)
        {
            _enquiriesService = enquiriesService;
            _reqinfo = r;
            this._logger = logger;
        }

        /// <summary>
        ///  Returns a list of all active referrer spammers
        /// </summary>
        ///<remarks>
        ///</remarks>
        [AllowAnonymous]
        [HttpGet]
        public Threenine.Data.Paging.IPaginate<Enquiry> Get(int PageNumber = 0, int PageSize = 30)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            PagingParams pagingParams = new PagingParams();
            pagingParams.PageNumber = PageNumber;
            pagingParams.PageSize = PageSize;
            _reqinfo.UserId = Request.Headers["UserId"].ToString();
            _reqinfo.BranchId = Request.Headers["BranchId"].ToString();
            _reqinfo.DeviceId = Request.Headers["DeviceId"].ToString();
            var Enquirys = _enquiriesService.GetAllActive(pagingParams);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            _logger.LogInformation("Fetching Follow up Modes");
            return Enquirys;
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
            _reqinfo.UserId = Request.Headers["UserId"].ToString();
            _reqinfo.BranchId = Request.Headers["BranchId"].ToString();
            _reqinfo.DeviceId = Request.Headers["DeviceId"].ToString();
            var identifier = _enquiriesService.Insert(referrer);


            return Ok();
        }
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] Enquiry referrer)
        {
            try
            {
                if (referrer == null)
                {
                    return BadRequest();
                }
                _reqinfo.UserId = Request.Headers["UserId"].ToString();
                _reqinfo.BranchId = Request.Headers["BranchId"].ToString();
                _reqinfo.DeviceId = Request.Headers["DeviceId"].ToString();
                var identifier = await _enquiriesService.Update(referrer);


                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
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
        [Route("Get/{identifier}", Name = "Enquiry")]
        public IActionResult Detail(string identifier)
        {
            _reqinfo.UserId = Request.Headers["UserId"].ToString();
            _reqinfo.BranchId = Request.Headers["BranchId"].ToString();
            _reqinfo.DeviceId = Request.Headers["DeviceId"].ToString();

            var referer = _enquiriesService.GetEnquiries(identifier);
            if (referer == null) return NotFound();

            return Ok(referer);
        }

    }
}