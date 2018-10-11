using Api.Database.Entity.Products;
using Microsoft.AspNetCore.Mvc;
using Swc.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace swcApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
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
    }
}
