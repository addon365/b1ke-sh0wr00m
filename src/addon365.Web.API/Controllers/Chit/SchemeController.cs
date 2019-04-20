using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using addon365.Database.Entity.Chit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using addon365.Database.Service.Chit;
using addon365.IService.Chit;

namespace addon365.Web.API.Controllers.Chit
{
    [Produces("application/json")]
    [Route("api/{license:license}/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SchemeController : ControllerBase
    {
        private readonly ISchemeService _schemeService;

        /// <inheritdoc />
        public SchemeController(ISchemeService schemeService)
        {
            _schemeService = schemeService;
        }
        // GET: api/Scheme
        [HttpGet]
        public IEnumerable<ChitScheme> Get()
        {
            return _schemeService.FindAll();
        }

        // GET: api/Scheme/5
        [HttpGet("{id}")]
        public ChitScheme Get(Guid id)
        {
            return _schemeService.Find(id);
        }

        // POST: api/Scheme
        [HttpPost]
        public IActionResult Post([FromBody] ChitScheme value)
        {
            var result = _schemeService.Save(value);
            return Ok(result);
        }

        // PUT: api/Scheme/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] ChitScheme value)
        {

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
