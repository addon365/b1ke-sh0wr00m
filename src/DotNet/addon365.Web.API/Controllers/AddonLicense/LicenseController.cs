//using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using addon365.Database.Entity.Inventory.Catalog;
using addon365.Database.Service;
using addon365.Domain.Entity.AddonLicense;
using addon365.IService.AddonLicense;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace addon365.Web.API.Controllers.AddonLicense
{
    [Produces("application/json")]
    [Route("api/{license:license}/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {

        private readonly IAddonLicenservice _Service;
        private RequestInfo _reqinfo;
        private readonly ILogger _logger;
        /// <inheritdoc />
        public LicenseController(IAddonLicenservice Service, RequestInfo r, ILogger<EnquiriesController> logger)
        {
            _Service = Service;
            _reqinfo = r;
            this._logger = logger;
        }

        // GET: api/License
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/License/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/License
        [HttpPost]
        [Route("Validation")]
        public void Validation([FromBody] LicenseValidationModel licenseValidationModel)
        {
            LicenseValidationModel lvm = licenseValidationModel;
            

        }

        [HttpPost]
        [Route("Create")]
        public void Create([FromBody] CustomerCatalogGroup csl)
        {
           
            csl.Id = Guid.NewGuid();

            _Service.Add(csl);
        }

        // PUT: api/License/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
      
    }
}
