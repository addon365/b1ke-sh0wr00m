using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        List<Enquiry> _enquiries  = new List<Enquiry>
            {
                new Enquiry(){ EnquiryId = 1, Name="Dana Birkby", MobileNumber="394-555-0181",Place="Villupuram"},
                new Enquiry(){ EnquiryId = 2, Name="Adriana Giorgi", MobileNumber="117-555-0119",Place="Trichy"},
                new Enquiry(){ EnquiryId = 3, Name="Wei Yu", MobileNumber="798-555-0118",Place="Vellore"}
            };

        // GET api/values
        [HttpGet]
        public IEnumerable<Enquiry> Get()
        {
            return _enquiries;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
