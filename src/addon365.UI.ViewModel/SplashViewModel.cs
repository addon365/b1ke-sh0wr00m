using addon365.WebClient.Service;
using addon365.Database.Entity.User;
using Newtonsoft.Json;
using addon365.Database.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using addon365.IService;

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
            _validationService = new addon365.WebClient.Service.WebService.ValidationService();
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
                WebDataClient.UpdateAuthToken(user.SessionToken);
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }

        }
    }
}
