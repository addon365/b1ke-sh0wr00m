using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Swc.Service.Sales;
using Api.Domain.Sales;

namespace swcApi.Controllers
{
    /// <inheritdoc />
    [Produces("application/json")]
    [Route("api/{license:license}/v{version:apiVersion}/[controller]")]
    public class SalesController : Controller
    {
        private readonly ISalesService _SalesService;

        /// <inheritdoc />
        public SalesController(ISalesService SalesService)
        {
            _SalesService = SalesService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] InsertSalesModel model)
        {

            if (model == null)
            {
                return BadRequest();
            }

            var identifier = _SalesService.Insert(model);


            return Ok();
        }

        [AllowAnonymous]
        [Route("InitilizeSales")]
        [HttpGet]
        public InitilizeSales GetInitilizeSales()
        {
            return _SalesService.GetInitilizeSales();
        }
      
    }
}