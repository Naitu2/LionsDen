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
    }
}
