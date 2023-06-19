using LionsDen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionsDen.Service
{
    class GymSession
    {
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }
        public TimeSpan SessionDuration => LogoutTime - LoginTime;

        public static void StartSession<TMember>(TMember memberToLogIn) where TMember : Member
        {
            var session = new GymSession { LoginTime = DateTime.Now };
            memberToLogIn.GymSessions.Add(session);
            memberToLogIn.CurrentSession = session;
            memberToLogIn.IsLoggedIn = true;
        }
        public static void EndSession<TMember>(TMember memberToLogOut) where TMember : Member
        {
            if (memberToLogOut.IsLoggedIn)
            {
                memberToLogOut.CurrentSession.LogoutTime = DateTime.Now;
                memberToLogOut.IsLoggedIn = false;
            }
        }
    }
}
