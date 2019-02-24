using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using addon365.Domain.Entity.Inventory;
using addon365.Domain.Entity.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using addon365.Database.Service;
using addon365.Database.Service.Inventory;

namespace addon365.Web.Api.Controllers.Inventory
{
    [Route("api/{license:license}/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductReportController : ControllerBase
    {
        private readonly IProductReportService _Service;
        private RequestInfo _reqinfo;
        private readonly ILogger _logger;
        public ProductReportController(IProductReportService Service, RequestInfo r, ILogger<ProductReportController> logger)
        {
            _Service = Service;
            _reqinfo = r;
            this._logger = logger;
        }

        [AllowAnonymous]
        [HttpGet("PurchaseProductWise")]
        public Threenine.Data.Paging.IPaginate<ProductWise> GetPurchaseProductWise(int PageNumber = 0, int PageSize = 30)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            PagingParams pagingParams = new PagingParams();
            pagingParams.PageNumber = PageNumber;
            pagingParams.PageSize = PageSize;
            _reqinfo.UserId = Request.Headers["UserId"].ToString();
            _reqinfo.BranchId = Request.Headers["BranchId"].ToString();
            _reqinfo.DeviceId = Request.Headers["DeviceId"].ToString();
            var List = _Service.GetAllPurchaseProductWise(pagingParams);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            _logger.LogInformation("Fetching Follow up Modes");
            return List;
        }
    }
}