using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace addon.BikeShowRoomService
{
    public class WebDataClient
    {

       
        private static HttpClient _client;

        
        private static void InitilizeClient()
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            _client = new HttpClient();
#if production
            _client.BaseAddress = new Uri("https://swcapi20181010045554.azurewebsites.net/api/svb/v1.0/");
#else
            _client.BaseAddress = new Uri("http://localhost:5000/api/svb/v1.0/");
#endif

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                 new MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        public static HttpClient Client
        {
            get
            {
                if (_client == null)
                    InitilizeClient();

                return _client;
            }
        }

    }
}
