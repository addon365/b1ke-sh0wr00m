using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using addon365.Database.Service;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using addon365.Domain.Entity.Paging;
using addon365.Database.Service.Inventory;
using addon365.Domain.Entity.Inventory;
using addon365.Database.Entity.Inventory.Purchases;
using addon365.Database.Entity.Inventory;

namespace addon365.Web.API.Controllers.Inventory
{
    /// <inheritdoc />
    [Produces("application/json")]
    [Route("api/{license:license}/v{version:apiVersion}/[controller]")]
    public class SellerController : Controller
    {
        private readonly ISellerService _Service;
        private RequestInfo _reqinfo;
        private readonly ILogger _logger;
        /// <inheritdoc />
        public SellerController(ISellerService Service, RequestInfo r, ILogger<SellerController> logger)
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
        public Threenine.Data.Paging.IPaginate<Seller> Get(int PageNumber=0,int PageSize=30)
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
        public IActionResult Post([FromBody] Seller model)
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
        public async Task<IActionResult> Update([FromBody] Seller referrer)
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
        [Route("Get/{identifier}")]
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