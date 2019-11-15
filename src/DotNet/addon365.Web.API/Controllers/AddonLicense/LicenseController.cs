//using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using addon365.Database.Entity.Inventory.Catalog;
using addon365.Database.Service;
using addon365.Domain.Entity.AddonLicense;
using addon365.Domain.Entity.EMail;
using addon365.IService.AddonLicense;
using addon365.IService.EMail;
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
        private IEmailService _EmailService;
        private RequestInfo _reqinfo;
        private readonly ILogger _logger;
        /// <inheritdoc />
        public LicenseController(IAddonLicenservice Service, IEmailService emailService, RequestInfo r, ILogger<EnquiriesController> logger)
        {
            _EmailService = emailService;
            _Service = Service;
            _reqinfo = r;
            this._logger = logger;
        }

        // GET: api/License

        [HttpGet("All")]
        public IEnumerable<LicenseDetail> Get() =>
        _Service.GetAll();

        // GET: api/License/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LicenseDetail> GetById(string id)
        {
            if (!_Service.TryGetLicense(id, out var license))
            {
                return NotFound();
            }

            return license;
        }

        [HttpGet]
        public IEnumerable<CustomerCatalogGroup> GetActiveLicenses()
        {
            var Licenses = _Service.GetLicenses();

            //foreach (var license in Licenses)
            //{
            //    if (license.Customer!=null)
            //    {
            //        yield return license;
            //    }
            //}
            return Licenses;
        }

        //[HttpGet("asyncsale")]
        //public async IAsyncEnumerable<Product> GetOnSaleProductsAsync()
        //{
        //    var products = _repository.GetProductsAsync();

        //    await foreach (var product in products)
        //    {
        //        if (product.IsOnSale)
        //        {
        //            yield return product;
        //        }
        //    }
        //}


        // POST: api/License
        [HttpPost]
        [Route("Validation")]
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LicenseDetail> Validation([FromBody] LicenseValidationModel licenseValidationModel)
        {
            LicenseValidationModel lvm = licenseValidationModel;
            if (!_Service.TryGetLicense(lvm.CustomerCatalogGroupId, out var license))
            {
                return NotFound();
            }
            //var Hardware = _Service.GetLicensedHardwares().Where(x => x.CustomerCatalogGroupId == License.id);

            //if(Hardware.Count()==0)
            //{
            //    await _Service.AddHardware(License.CustomerCatalogGroupId, lvm.HardwareId);              
            //}

            return Ok(license);
        }

        [HttpPost]
        [Route("Activation")]
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LicenseDetail>> Activation([FromBody] LicenseActivationDetail licenseActivationDetail)
        {
            LicenseActivationDetail lad = licenseActivationDetail;
            if (!_Service.TryGetLicense(lad.CustomerCatalogGroupId, out var license))
            {
                return NotFound();
            }
            var Hardware = _Service.GetLicensedHardwares().Where(x => x.CustomerCatalogGroupId == Guid.Parse(license.CustomerCatalogGroupId));
            var v = Hardware.Where(x => x.HardwareId == licenseActivationDetail.HardwareId);
            if (v.Count() == 0)
            {

                if (Hardware.Count() > license.NumberofSystem)
                    return BadRequest();
                else
                    _Service.AddHardware(licenseActivationDetail);


            }
            else
            {
                if (lad.CallType == Domain.Entity.ActivateCallType.CheckIn)
                {

                }
            }



            if (lad.CallType == Domain.Entity.ActivateCallType.FirstTime)
            {

                _Service.ActivateLicense(licenseActivationDetail);
            }

            //return CreatedAtAction(nameof(GetById), new { id = license.CustomerCatalogGroupId }, license);
            if (!_Service.TryGetLicense(lad.CustomerCatalogGroupId, out var Rlicense))
            {
                return NotFound();
            }
            return Ok(Rlicense);
        }

        [HttpPost]
        [Route("Create")]
        public async void Create([FromBody] CustomerCatalogGroup csl)
        {

            csl.Id = Guid.NewGuid();
            csl.CustomerCatalogGroupId = Guid.NewGuid().ToString();


            _Service.Add(csl);
            EmailMessage eMailMessage = new EmailMessage();
            eMailMessage.FromAddresses.Add(new EmailAddress { Address = "tamilselvanid@outlook.com", Name = "Tamilselvan" });
            eMailMessage.ToAddresses.Add(new EmailAddress { Address = "tamilselvan@addon.cc", Name = "Old mail" });
            eMailMessage.Subject = "Checking Mail from ASP CORE";
            eMailMessage.Content = "HELLO";
            _EmailService.Send(eMailMessage);

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
