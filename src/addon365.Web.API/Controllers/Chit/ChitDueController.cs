using addon365.Database.Entity.Chit;
using addon365.Domain.Entity.Chit;
using addon365.IService.Accounts;
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
    public class ChitDueController : ControllerBase
    {
        public const string VOUCHER_TYPE_NAME = "Chit";
        IChitDueService _chitDueService;
        IVoucherTypeService _voucherTypeService;
        IAccountBookService _accountBookService;
        public ChitDueController(IChitDueService chitDueService,
            IVoucherTypeService voucherTypeService,
            IAccountBookService accountBookService)
        {
            this._chitDueService = chitDueService;
            _voucherTypeService = voucherTypeService;
            _accountBookService = accountBookService;
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

        // GET: api/ChitDue/5
        [HttpGet("subscriber/mobile/{number}")]
        public IList<CustomerDueDomain> GetSubscriptions(string number)
        {
            return _chitDueService.FindByMobile(number);
        }

        [HttpGet("subscriber/customerName/{name}")]
        public IList<CustomerDueDomain> GetSubscriptionsByName(string name)
        {
            return _chitDueService.FindByCustomerName(name);
        }

        // POST: api/ChitDue
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult Post([FromBody] ChitSubscribeDomain value)
        {
            var resultObj = _chitDueService.Save(value);
            return Ok(resultObj);
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
