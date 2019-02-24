using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace addon365.Database.Service
{
    public interface IValidationService
    {
        Task<HttpResponseMessage> GetServerStatus();
    }
}
