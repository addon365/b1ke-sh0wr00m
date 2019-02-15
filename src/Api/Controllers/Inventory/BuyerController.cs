using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swc.Service;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Api.Domain.Paging;
using Swc.Service.Inventory;
using Api.Domain.Inventory;
using Api.Database.Entity.Inventory.Purchases;
using Api.Database.Entity.Inventory;

namespace swcApi.Controllers.Inventory
{
    /// <inheritdoc />
    [Produces("application/json")]
    [Route("api/{license:license}/v{version:apiVersion}/[controller]")]
    public class BuyerController : Controller
    {
        private readonly IBuyerService _Service;
        private RequestInfo _reqinfo;
        private readonly ILogger _logger;
        /// <inheritdoc />
        public BuyerController(IBuyerService Service, RequestInfo r, ILogger<EnquiriesController> logger)
        {
            _Service = Service;
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
        public Threenine.Data.Paging.IPaginate<Buyer> Get(int PageNumber=0,int PageSize=30)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            
            PagingParams pagingParams = new PagingParams();
            pagingParams.PageNumber = PageNumber;
            pagingParams.PageSize = PageSize;
            _reqinfo.UserId = Request.Headers["UserId"].ToString();
            _reqinfo.BranchId = Request.Headers["BranchId"].ToString();
            _reqinfo.DeviceId = Request.Headers["DeviceId"].ToString();
            var List= _Service.GetAll(pagingParams);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            _logger.LogInformation("Fetching Follow up Modes");
            return List;
        }
        

        /// <summary>
        ///  Returns a collection of values
        /// </summary>
        ///<remarks>
        /// This is a remark to add additional information about this method
        ///</remarks>
        [HttpPost]
        public IActionResult Post([FromBody] Buyer model)
        {
            
                if (model == null)
            {
                return BadRequest();
            }
            _reqinfo.UserId = Request.Headers["UserId"].ToString();
            _reqinfo.BranchId = Request.Headers["BranchId"].ToString();
            _reqinfo.DeviceId = Request.Headers["DeviceId"].ToString();
            var identifier = _Service.Insert(model);


            return Ok() ;
        }
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] Buyer referrer)
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
            var identifier =await _Service.Update(referrer);


            return Ok();
            }
            catch(Exception ex)
            {
                return NotFound(ex);
            }
        }
       
        [HttpGet]
        [Route("{identifier}")]
        public IActionResult Detail(string identifier)
        {
            _reqinfo.UserId = Request.Headers["UserId"].ToString();
            _reqinfo.BranchId = Request.Headers["BranchId"].ToString();
            _reqinfo.DeviceId = Request.Headers["DeviceId"].ToString();

            var referer = _Service.Get(identifier);
            if (referer == null) return NotFound();

            return Ok(referer);
        }
       
    }
}