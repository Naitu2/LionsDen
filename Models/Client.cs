using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace LionsDen.Models
{
    internal class Client : Member
    {

        public double Height { get; set; }
        public double Weight { get; set; }
        public int FatPercentage { get; set; }
        public string MembershipDuration { get; set; }
        public DateTime MembershipExpirationDate { get; set; }
        public string AssignedTraining { get; set; }

        public static string GetAssignedTraining(Client checkedClient)
        {
            double bmi = checkedClient.Weight / Math.Pow(checkedClient.Height, 2);

            if (bmi < 18.5)
            {
                return "Strength";
            }
            else if (bmi >= 18.5 && bmi < 25 && checkedClient.FatPercentage < 25)
            {
                return "Cardio";
            }
            else
            {
                return "Yoga";
            }
        }

        

    }


}
