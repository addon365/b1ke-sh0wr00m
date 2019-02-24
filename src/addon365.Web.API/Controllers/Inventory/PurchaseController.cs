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

namespace addon365.Web.Api.Controllers.Inventory
{
    /// <inheritdoc />
    [Produces("application/json")]
    [Route("api/{license:license}/v{version:apiVersion}/[controller]")]
    public class PurchaseController : Controller
    {
        private readonly IPurchaseService _PurchaseService;
        private RequestInfo _reqinfo;
        private readonly ILogger _logger;
        /// <inheritdoc />
        public PurchaseController(IPurchaseService PurchaseService, RequestInfo r, ILogger<EnquiriesController> logger)
        {
            _PurchaseService = PurchaseService;
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
        public Threenine.Data.Paging.IPaginate<Purchase> Get(int PageNumber=0,int PageSize=30)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            
            PagingParams pagingParams = new PagingParams();
            pagingParams.PageNumber = PageNumber;
            pagingParams.PageSize = PageSize;
            _reqinfo.UserId = Request.Headers["UserId"].ToString();
            _reqinfo.BranchId = Request.Headers["BranchId"].ToString();
            _reqinfo.DeviceId = Request.Headers["DeviceId"].ToString();
            var PurchaseList= _PurchaseService.GetAll(pagingParams);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            _logger.LogInformation("Fetching Follow up Modes");
            return PurchaseList;
        }
        

        [AllowAnonymous]
        [Route("Init")]
        [HttpGet]
        public PurchaseMasterData GetInitilize()
        {
            return _PurchaseService.GetInitilize();
        }
        /// <summary>
        ///  Returns a collection of values
        /// </summary>
        ///<remarks>
        /// This is a remark to add additional information about this method
        ///</remarks>
        [HttpPost]
        public IActionResult Post([FromBody] Purchase model)
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
                var identifier = _PurchaseService.Insert(model);


                return Ok();
            }
            catch(Exception ex)
            {
                return NotFound(ex);
            }
        }
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] Purchase referrer)
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
            var identifier =await _PurchaseService.Update(referrer);


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

            var referer = _PurchaseService.Get(identifier);
            if (referer == null) return NotFound();

            return Ok(referer);
        }
       
    }
}