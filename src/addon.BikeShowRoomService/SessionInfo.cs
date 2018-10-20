using Api.Database.Entity.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace addon.BikeShowRoomService
{
    public class SessionInfo
    {
        public const string SessionFile= "SessionInfo.json";
        private static SessionInfo _objSelf;
        private DateTime _startDateTime;
        public static SessionInfo Instance
        {
            get
            {
                if (_objSelf == null)
                { 
                   _objSelf=new SessionInfo();
                    _objSelf._startDateTime = DateTime.Now;
                }

                return _objSelf;
            }
        }
        public User user { get; set; }
        public DateTime SessionStartDateTime { get;  }

    }
}
