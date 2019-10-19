using addon365.Database.Entity.Chit;
using addon365.Database.Entity.Crm;
using addon365.Domain.Entity.Chit.Reports;
using addon365.IService.Chit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace addon365.Web.API.Controllers.Chit
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

        // GET: api/Subscribe/5
        [HttpGet("{id}")]
        public ChitSubscriber Get(Guid id)
        {
            return _subscribeService.Find(id);
        }

        // GET: api/Subscribe/5
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get([FromQuery(Name = "subscriptionId")]string id)
        {
            if (id == null)
                return Ok(_subscribeService.FindAll());
            var result = _subscribeService.FindBySubscriptionId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
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
        public void Put(Guid id, [FromBody] ChitSubscriber chitSubscriber)
        {

        }

        [HttpPut("close/{subscriptionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status304NotModified)]
        [ProducesDefaultResponseType]
        public ActionResult<string> CloseSubscription(string subscriptionId, [FromForm]double amount)
        {
            string result = _subscribeService.CloseSubscription(subscriptionId, amount);
            if (result == null)
                return Ok("Successfully closed subscription.");
            return StatusCode(StatusCodes.Status304NotModified, result);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
        [HttpGet("fetchReport/{schemeId}/{customerId}")]
        public IList<SubscriberReportDomain> FetchReport(Guid schemeId, Guid customerId)
        {
            return _subscribeService.FetchReport(schemeId, customerId);
        }
        [HttpGet("customers")]
        public IList<Customer> FindAllCustomers()
        {
            return _subscribeService.FindAllCustomers();
        }


    }
}
