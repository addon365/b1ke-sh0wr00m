using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace addon365.Web.API.Utils
{
    public class AppSettings
    {
        //TODO: Need to remove once the secret key retrieved from appsetings. see startup.cs
        public static string SECRET = "43d4f358-0cf8-4e5e-b738-26653756d3f1";
        public string Secret { get; set; }
    }
}
