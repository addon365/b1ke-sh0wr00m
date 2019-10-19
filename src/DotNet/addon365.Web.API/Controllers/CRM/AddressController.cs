using addon365.IService.Crm.Address;
using Microsoft.AspNetCore.Mvc;

namespace addon365.Web.API.Controllers.CRM
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {

        private ISubDistrictService _subDistrictService;
        private IStateService _stateService;
        private IDistrictService _districtService;
        private ILocalityService _localityService;
        private IPincodeService _pincodeService;

        public AddressController(
            IStateService stateService,
            IDistrictService districtService,
            ISubDistrictService subDistrictService,
            ILocalityService localityService,
            IPincodeService pincodeService
            )
        {
            this._stateService = stateService;
            this._districtService = districtService;
            this._subDistrictService = subDistrictService;
            this._localityService = localityService;
            this._pincodeService = pincodeService;
        }


        [HttpGet("states")]
        public IActionResult GetStates()
        {
            return Ok(_stateService.FindAll());
        }

        [HttpGet("districts")]
        public IActionResult GetDistricts()
        {
            return Ok(_districtService.FindAll());
        }

        [HttpGet("subdistricts")]
        public IActionResult GetSubDistricts()
        {
            return Ok(_subDistrictService.FindAll());
        }

        [HttpGet("localities")]
        public IActionResult GetLocalities()
        {
            return Ok(_localityService.FindAll());
        }
        [HttpGet("pincodes")]
        public IActionResult GetPincodes()
        {
            return Ok(_pincodeService.FindAll());
        }
    }
}