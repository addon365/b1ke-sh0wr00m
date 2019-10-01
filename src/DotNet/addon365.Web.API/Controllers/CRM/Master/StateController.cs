using addon365.Database.Entity.Crm.Address;
using addon365.IService.Crm.Address;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace addon365.Web.API.Controllers.CRM.Master
{
    [Route("api/master/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private IStateService _stateService;
        private readonly ILogger _logger;

        public StateController(IStateService stateService)
        {
            this._stateService = stateService;
           
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        [ProducesDefaultResponseType]
        public IActionResult AddState([FromBody] StateMaster state)
        {
            StateMaster createdState = _stateService.Save(state);
            if (createdState == null)
            {
                _logger.LogError("User already exists");
                return StatusCode(StatusCodes.Status409Conflict, "User Already Exists");
            }
            return Ok(createdState);
        }

        [HttpGet("all")]
        public IActionResult GetStatesAll()
        {
            return Ok(_stateService.FindAll());
        }
    }
}