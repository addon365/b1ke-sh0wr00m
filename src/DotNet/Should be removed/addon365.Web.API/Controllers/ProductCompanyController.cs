﻿using addon365.Database.Entity.Inventory.Catalog;
using addon365.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace addon365.Web.API.Controllers
{
    [Produces("application/json")]
    [Route("api/{license:license}/v{version:apiVersion}/[controller]")]
    public class ProductCompanyController : Controller
    {
        private readonly IProductCompanyService _productcompanyService;
        public ProductCompanyController(IProductCompanyService productcompanyService)
        {
            _productcompanyService = productcompanyService;
        }
        [HttpGet]
        public IEnumerable<CatalogBrand> Get()
        {
            return _productcompanyService.GetAllProductCompanies();
        }

        [HttpPost]
        public IActionResult ProductCompanyPost([FromBody] CatalogBrand referrer)
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
        public IActionResult Delete([FromBody] CatalogBrand productcompany)
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
