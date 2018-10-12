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
            _client.BaseAddress = new Uri("http://localhost:5000/");

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
