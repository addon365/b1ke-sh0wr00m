using Api.Database.Entity.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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
    public class AccessoriesController : Controller
    {
        private readonly IAccessoriesService _accessoriesService;

        /// <inheritdoc />
        /// 
        public AccessoriesController(IAccessoriesService accessoriesService)
        {
            _accessoriesService = accessoriesService;

        }


        [HttpPost("add")]
        public IActionResult AccessoriesPost([FromBody] IEnumerable<ExtraFittingsAccessories> referrer)
        {
            if (referrer == null)
            {
                return BadRequest();
            }


            var identifier = _accessoriesService.InsertAccessories(referrer);


            return Ok();
        }
        [HttpPost("update")]
        public IActionResult AccessoriesUpdatePost([FromBody] IEnumerable<ExtraFittingsAccessories> referrer)
        {
            if (referrer == null)
            {
                return BadRequest();
            }


            var identifier = _accessoriesService.UpdateAccessories(referrer);


            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAccessories()
        {
            return Ok(_accessoriesService.GetAccessories());
        }
        [HttpGet("{Id}")]
        public IActionResult GetAccessories(Guid Id)
        {
            return Ok(_accessoriesService.GetAccessories(Id));
        }

        [HttpGet("Delete/{Id}")]
        public IActionResult GetDeleteAccessories(Guid Id)
        {
            _accessoriesService.DeleteAccessories(Id);
            return Ok();
        }


    }
}
