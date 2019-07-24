using addon365.Database.Entity.Enquiries;
using addon365.Database.Service;
using addon365.Domain.Entity.Paging;
using addon365.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace addon365.Web.API.Controllers
{
    /// <inheritdoc />
    [Produces("application/json")]
    [Route("api/{license:license}/v{version:apiVersion}/[controller]")]
    public class BookingController : Controller
    {
        private readonly IBookingService _BookingService;
        private RequestInfo _reqinfo;

        /// <inheritdoc />
        public BookingController(IBookingService BookingService, RequestInfo r)
        {
            _BookingService = BookingService;
            _reqinfo = r;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Enquiry model)
        {
            try
            {

                if (model == null)
                {
                    return BadRequest();
                }
                _reqinfo.UserId = Request.Headers["UserId"].ToString();
                _reqinfo.BranchId = Request.Headers["BranchId"].ToString();
                _reqinfo.DeviceId = Request.Headers["DeviceId"].ToString();

                await _BookingService.Insert(model);


                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public Threenine.Data.Paging.IPaginate<Enquiry> Booked(int PageNumber = 0, int PageSize = 30)
        {
            PagingParams pagingParams = new PagingParams();
            pagingParams.PageNumber = PageNumber;
            pagingParams.PageSize = PageSize;
            _reqinfo.UserId = Request.Headers["UserId"].ToString();
            _reqinfo.BranchId = Request.Headers["BranchId"].ToString();
            _reqinfo.DeviceId = Request.Headers["DeviceId"].ToString();
            return _BookingService.GetAllBooked(pagingParams);
        }
        [HttpGet]
        [Route("Booked/Get/{identifier}")]
        public IActionResult GetBooked(string identifier)
        {
            _reqinfo.UserId = Request.Headers["UserId"].ToString();
            _reqinfo.BranchId = Request.Headers["BranchId"].ToString();
            _reqinfo.DeviceId = Request.Headers["DeviceId"].ToString();

            var referer = _BookingService.GetBooked(identifier);
            if (referer == null) return NotFound();

            return Ok(referer);
        }


    }
}