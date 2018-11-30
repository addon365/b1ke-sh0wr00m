using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Swc.Service.Sales;
using Api.Domain.Sales;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Post([FromBody] InsertSalesModel model)
        {
            try
            { 
         
                if (model == null)
                {
                    return BadRequest();
                }

                var identifier =await _SalesService.Insert(model);


                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
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