using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Swc.Service
{
    public interface IValidationService
    {
        Task<HttpResponseMessage> GetServerStatus();
    }
}
