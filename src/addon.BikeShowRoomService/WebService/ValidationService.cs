using Swc.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace addon.BikeShowRoomService.WebService
{
    public class ValidationService : IValidationService
    {
        public Task<HttpResponseMessage> GetServerStatus()
        {
            HttpClient httpClient=WebDataClient.Client;
            return httpClient.GetAsync("/api/svb/v1.0/echo");
        }
    }
}
