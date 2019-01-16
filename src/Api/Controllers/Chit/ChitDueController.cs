using System;
using System.Collections.Generic;
using Api.Database.Entity.Chit;
using Microsoft.AspNetCore.Mvc;
using Swc.Service.Accounts;
using Swc.Service.Chit;
using Microsoft.AspNetCore.Http;
using Api.Database.Entity.Accounts;
using Api.Domain.Chit;

namespace swcApi.Controllers.Chit
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
