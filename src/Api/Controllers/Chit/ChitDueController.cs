using System;
using System.Collections.Generic;
using Api.Database.Entity.Chit;
using Microsoft.AspNetCore.Mvc;
using Swc.Service.Chit;

namespace swcApi.Controllers.Chit
{
    [Produces("application/json")]
    [Route("api/{license:license}/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ChitDueController : ControllerBase
    {
        IChitDueService _chitDueService;
        public ChitDueController(IChitDueService chitDueService)
        {
            this._chitDueService = chitDueService;
        }
        // GET: api/ChitDue
        [HttpGet]
        public IEnumerable<ChitSubriberDue> Get()
        {
            return _chitDueService.FindAll();
        }

        // GET: api/ChitDue/5
        [HttpGet("{id}")]
        public ChitSubriberDue Get(Guid id)
        {
            return _chitDueService.Find(id);
        }

        // GET: api/ChitDue/5
        [HttpGet("subscriber/{id}")]
        public List<ChitSubriberDue> GetSubscriberId(Guid id)
        {
            return _chitDueService.GetList(id);
        }

        // POST: api/ChitDue
        [HttpPost]
        public IActionResult Post([FromBody] ChitSubriberDue value)
        {
            value.DueNo = _chitDueService.GenerateDueId();
            if (value.ChitSubscriber != null)
            {
                value.ChitSubscriber.SubscribeId =
                    _chitDueService.GenerateSubscribeId();
            }
            return Ok(_chitDueService.Save(value));
        }

        // PUT: api/ChitDue/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] ChitSubriberDue value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
