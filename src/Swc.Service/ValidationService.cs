using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Swc.Service
{
    class ValidationService : IValidationService
    {
        public Task<HttpResponseMessage> GetServerStatus()
        {
            throw new NotImplementedException();
        }
    }
}
