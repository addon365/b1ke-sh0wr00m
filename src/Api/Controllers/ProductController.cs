﻿using Api.Database.Entity.Products;
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


            return CreatedAtRoute("ProductDetail", new { identifier }, referrer);
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
