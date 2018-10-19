using addon.BikeShowRoomService;
using Api.Database.Entity.User;
using Swc.Service;
using System;
using System.Collections.Generic;
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
        public void ValidateUser()
        {


            ValidateUserCommand.IsEnabled = false;



            User user = _repository.Validate(CurrentUser.UserId, CurrentUser.Password);

            if(user!=null)
            {
                SessionInfo si = SessionInfo.Instance;
                si.user = user;

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
        public IViewUI LoginSuccess { get; set; }
        public IViewUI LoginFailed { get; set; }

    }
}
