﻿using addon365.Database.Entity.Inventory.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using addon365.Database.Service;
using System.Collections.Generic;

namespace addon365.Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/{license:license}/v{version:apiVersion}/[controller]")]
    public class ProductCompanyController: Controller
    {
        private readonly IProductCompanyService _productcompanyService;
        public ProductCompanyController(IProductCompanyService productcompanyService)
        {
            _productcompanyService = productcompanyService;
        }
        [HttpGet]
        public IEnumerable<ProductCompany> Get()
        {
            return _productcompanyService.GetAllProductCompanies();
        }

        [HttpPost]
        public IActionResult ProductCompanyPost([FromBody] ProductCompany referrer)
        {
            if (referrer == null)
            {
                return BadRequest();
            }

            var identifier = _productcompanyService.Insert(referrer);


            return Ok();
        }

        [HttpGet]
        [Route("{identifier}", Name = "ProductCompanyDetail")]
        public IActionResult Detail(string identifier)
        {
            var referer = _productcompanyService.GetProductCompany(identifier);
            if (referer == null) return NotFound();

            return Ok(referer);
        }

        [AllowAnonymous]
        [Route("Delete")]
        [HttpPost]
        public IActionResult Delete([FromBody] ProductCompany productcompany)
        {
            if (productcompany == null)
            {
                return BadRequest();
            }

            _productcompanyService.Delete(productcompany);


            return Ok();
        }
    }
}