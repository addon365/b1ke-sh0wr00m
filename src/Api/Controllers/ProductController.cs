using Api.Database.Entity.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swc.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace swcApi.Controllers
{
    /// <inheritdoc />
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProductController :Controller
    {
        private readonly IProductService _productService;

        /// <inheritdoc />
        /// 
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        ///  Returns a list of all active referrer spammers
        /// </summary>
        ///<remarks>
        ///</remarks>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.GetAllActive();
        }

        /// <summary>
        ///  Returns Details of a selected Referrer
        /// </summary>
        ///<remarks>
        ///
        ///</remarks>
        [HttpGet("{Id}")]
        public IEnumerable<Product> Get(int Id)
        {
            return _productService.GetProductByType(Id);

        }

        [AllowAnonymous]
        [Route("Companies")]
        [HttpGet]
        public IEnumerable<ProductCompany> GetCompanies()
        {
            return _productService.GetCompanies();
        }

        [AllowAnonymous]
        [Route("Types")]
        [HttpGet]
        public IEnumerable<ProductType> GetTypes()
        {
            return _productService.GetTypes();
        }

        /// <summary>
        ///  Returns a collection of values
        /// </summary>
        ///<remarks>
        /// This is a remark to add additional information about this method
        ///</remarks>

        [HttpPost]
        public IActionResult ProductPost([FromBody] Product referrer)
        {
            if (referrer == null)
            {
                return BadRequest();
            }

            var identifier = _productService.Insert(referrer);


            return Ok();
        }

        [HttpPost("accessories")]
        public IActionResult AccessoriesPost([FromBody] Product referrer)
        {
            if (referrer == null)
            {
                return BadRequest();
            }

            var identifier = _productService.Insert(referrer);


            return Ok();
        }
        [AllowAnonymous]
        [Route("Delete")]
        [HttpPost]
        public IActionResult Delete([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            _productService.Delete(product);


            return Ok();
        }

        /// <summary>
        ///  Returns Details of a selected Referrer
        /// </summary>
        ///<remarks>
        ///
        ///</remarks>
        [HttpGet]
        [Route("{identifier}", Name = "ProductDetail")]
        public IActionResult Detail(string identifier)
        {
            var referer = _productService.GetProduct(identifier);
            if (referer == null) return NotFound();

            return Ok(referer);
        }
        
    }
}
