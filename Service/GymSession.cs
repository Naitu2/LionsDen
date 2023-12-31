﻿using LionsDen.Models;
using System;
using System.Linq;

namespace LionsDen.Service
{
    class GymSession
    {
        public DateTime LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
        public TimeSpan SessionDuration => (LogoutTime.HasValue ? LogoutTime.Value : DateTime.Now) - LoginTime;

        public static void StartSession<TMember>(TMember memberToLogIn) where TMember : Member
        {
            var session = new GymSession { LoginTime = DateTime.Now };
            memberToLogIn.GymSessions.Add(session);
            memberToLogIn.IsLoggedIn = true;
            FileExplorer.UpdateMemberData(memberToLogIn, 'i');
        }

        public static void EndSession<TMember>(TMember memberToLogOut) where TMember : Member
        {
            if (memberToLogOut.IsLoggedIn)
            {
                memberToLogOut.GymSessions.LastOrDefault().LogoutTime = DateTime.Now;
                memberToLogOut.IsLoggedIn = false;
                FileExplorer.UpdateMemberData(memberToLogOut, 'o');
            }
        }
    }
}
