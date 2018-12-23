using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Database.Entity.Chit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swc.Service.Chit;

namespace swcApi.Controllers.Chit
{
    [Produces("application/json")]
    [Route("api/{license:license}/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;

        /// <inheritdoc />
        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }
        // GET: api/Subscribe
        [HttpGet]
        public IEnumerable<ChitSubscriber> Get()
        {
            return _subscribeService.FindAll();
        }

        // GET: api/Subscribe/5
        [HttpGet("{id}")]
        public ChitSubscriber Get(Guid id)
        {
            return _subscribeService.Find(id);
        }

        // POST: api/Subscribe
        [HttpPost]
        public IActionResult Post([FromBody] ChitSubscriber value)
        {
            var result = _subscribeService.Save(value);
            return Ok(result);
        }

        // PUT: api/Subscribe/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] ChitSubscriber value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
