using addon365.Database.Entity.Users;
using addon365.Database.Service;
using addon365.IService;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Management;
using System.Net.Http;
using System.Threading.Tasks;

namespace addon365.UI.ViewModel
{
    public class SplashViewModel : ViewModelBase
    {
        private readonly IValidationService _validationService;
        private bool _showRetry;
        public delegate void DoSomething();
        public DoSomething InvokeCaller { get; set; }
        public SplashViewModel(DoSomething doSomething)
        {
#if !Desktop
            var Scope = Startup.Instance.provider.CreateScope();
            _validationService = Scope.ServiceProvider.GetRequiredService<IValidationService>();

#endif
            // _validationService = new addon365.WebClient.Service.WebService.ValidationService();
            InvokeCaller = doSomething;
            RetryCommand = new RelayCommand(()=>InvokeCaller());

        }
        public RelayCommand RetryCommand { get; private set; }
        
        public bool ShowRetry
        {
            get
            {
                return _showRetry;
            }
            set
            {
                if (ShowRetry != value)
                {
                    _showRetry = value;
                    OnPropertyChanged("ShowRetry");
                    RetryCommand.IsEnabled = true;
                }
            }
        }
        public Task<HttpResponseMessage> GetServiceStatus()
        {
          

            return _validationService.GetServerStatus();
        }
        public bool HasSessionInfo()
        {

            if (!System.IO.File.Exists(SessionInfo.SessionFile))
            {
                return false;
            }
            return true;
        }
        public bool UpdateSessionInfo()
        {
            string json = System.IO.File.ReadAllText(SessionInfo.SessionFile);
            if (string.IsNullOrEmpty(json))
                return false;
            try
            {
                User user = JsonConvert.DeserializeObject<User>(json);
                SessionInfo.Instance.user = user;
#if Desktop
                var Scope = Startup.Instance.provider.CreateScope();
                RequestInfo _reqinfo = Scope.ServiceProvider.GetRequiredService<RequestInfo>();
                _reqinfo.BranchId = "150e0313-cf22-491c-93c4-4925b4d9e969";
                _reqinfo.DeviceCode = getUniqueID("C");
                //_reqinfo.DeviceCode = Request.Headers["DeviceCode"].ToString();
                //_reqinfo.Init(userId);
#else
                 addon365.WebDataClient.UpdateAuthToken(user.SessionToken);
#endif


                return true;
            }
            catch (Exception exception)
            {
                return false;
            }

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
