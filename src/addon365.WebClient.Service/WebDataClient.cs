using System;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace addon365.WebClient.Service
{
    public class WebDataClient
    {

       
        private static HttpClient _client;

        
        private static void InitilizeClient()
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            _client = new HttpClient();
#if !DEBUG
            _client.BaseAddress = new Uri("https://addon365.Web.Api20181212091502.azurewebsites.net/api/svb/v1.0/");
#else
            _client.BaseAddress = new Uri("http://localhost:5000/api/svb/v1.0/");
#endif

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                 new MediaTypeWithQualityHeaderValue("application/json"));
           
            _client.DefaultRequestHeaders.Add("DeviceCode", getUniqueID("C"));
            _client.DefaultRequestHeaders.Add("BranchId", "150e0313-cf22-491c-93c4-4925b4d9e969");
            

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

        public static void UpdateAuthToken(string tokenAsBase64)
        {     
            var header = new AuthenticationHeaderValue("Bearer", tokenAsBase64);
            Client.DefaultRequestHeaders.Authorization = header;
            //Client.DefaultRequestHeaders.Add("DeviceId", SessionInfo.Instance.user.DeviceId.ToString());
            //Client.DefaultRequestHeaders.Add("LicenseId", SessionInfo.Instance.user.LicenseId.ToString());
            //Client.DefaultRequestHeaders.Add("UserId", SessionInfo.Instance.user.Id.ToString());
        }
        public static string getUniqueID(string drive)
        {
            if (drive == string.Empty)
            {
                //Find first drive
                foreach (DriveInfo compDrive in DriveInfo.GetDrives())
                {
                    if (compDrive.IsReady)
                    {
                        drive = compDrive.RootDirectory.ToString();
                        break;
                    }
                }
            }

            if (drive.EndsWith(":\\"))
            {
                //C:\ -> C
                drive = drive.Substring(0, drive.Length - 2);
            }

            string volumeSerial = getVolumeSerial(drive);
            string cpuID = getCPUID();


            //Mix them up and remove some useless 0's
            return cpuID.Substring(13) + cpuID.Substring(1, 4) + volumeSerial + cpuID.Substring(4, 4);
        }

        private static string getVolumeSerial(string drive)
        {
            System.Management.ManagementObject disk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
            disk.Get();

            string volumeSerial = disk["VolumeSerialNumber"].ToString();
            disk.Dispose();

            return volumeSerial;
        }

        private static string getCPUID()
        {
            string cpuInfo = "";
            ManagementClass managClass = new ManagementClass("win32_processor");
            ManagementObjectCollection managCollec = managClass.GetInstances();

            foreach (ManagementObject managObj in managCollec)
            {
                if (cpuInfo == "")
                {
                    //Get only the first CPU's ID
                    if (managObj.Properties["processorID"].Value != null)
                        cpuInfo = managObj.Properties["processorID"].Value.ToString();
                    else
                        cpuInfo = "BFEBFBFF000406E3";

                    break;
                }
            }

            return cpuInfo;
        }


    }

}
