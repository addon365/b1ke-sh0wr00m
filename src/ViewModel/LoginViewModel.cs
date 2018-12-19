using addon.BikeShowRoomService;
using Api.Database.Entity.User;
using Newtonsoft.Json;
using Swc.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IUserService _repository;
        private User _currentUser;
        public LoginViewModel()
        {
            _repository = new addon.BikeShowRoomService.WebService.UserService();

            WireCommands();
            initInsert();
        }
        private void WireCommands()
        {
            ValidateUserCommand = new RelayCommand(ValidateUser);
        }
        public RelayCommand ValidateUserCommand
        {
            get;
            private set;
        }
        void initInsert()
        {

            CurrentUser = new User();

        }

        public User CurrentUser
        {
            get
            {
                return _currentUser;
            }

            set
            {
                if (CurrentUser != value)
                {
                    _currentUser = value;
                    OnPropertyChanged("CurrentUser");
                    ValidateUserCommand.IsEnabled = true;

                }
            }
        }
        
        [Conditional("DEBUG")]
        private void StoreSessionInfoAsync(User user)
        {
           using(System.IO.StreamWriter writer=new System.IO.StreamWriter(SessionInfo.SessionFile))
            {
                string json = JsonConvert.SerializeObject(user);
                writer.Write(json);
            }
        }
        public void ValidateUser()
        {
            try
            {


                ValidateUserCommand.IsEnabled = false;



                User user = _repository.Validate(CurrentUser.UserId, CurrentUser.Password);

                if (user != null)
                {
                    SessionInfo si = SessionInfo.Instance;
                    si.user = user;

                    WebDataClient.UpdateAuthToken(user.SessionToken);


                    StoreSessionInfoAsync(user);
                    if (LoginSuccess != null)
                        LoginSuccess.ShowUI();


                }
                else
                {
                    if (LoginFailed != null)
                        LoginFailed.ShowUI();

                    ValidateUserCommand.IsEnabled = true;
                }
            }
            catch(Exception ex)
            {
                msgBox.ShowUI(ex.Message);
            }


        }
        public IViewUI LoginSuccess { get; set; }
        public IViewUI LoginFailed { get; set; }
        public IMsgBox msgBox { get; set; }

    }
}
