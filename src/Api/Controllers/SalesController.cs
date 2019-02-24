using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using addon365.Database.Service.Sales;
using addon365.Domain.Entity.Sales;
using System;
using System.Threading.Tasks;
using addon365.Database.Entity.Inventory.Sales;

namespace addon365.Web.Api.Controllers
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
        public async Task<IActionResult> Post([FromBody] Sale Model)
        {
            try
            { 
         
                if (Model == null)
                {
                    return BadRequest();
                }

                var identifier =await _SalesService.Insert(Model);


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