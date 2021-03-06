﻿using addon365.Database.Entity.Inventory.Sales;
using addon365.Domain.Entity.Sales;
using addon365.IService.Sales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace addon365.Web.API.Controllers
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

                var identifier = await _SalesService.Insert(Model);


                return Ok();
            }
            catch (Exception ex)
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