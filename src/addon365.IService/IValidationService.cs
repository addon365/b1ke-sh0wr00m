using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace addon365.IService
{
    public interface IValidationService
    {
        Task<HttpResponseMessage> GetServerStatus();
    }
}
