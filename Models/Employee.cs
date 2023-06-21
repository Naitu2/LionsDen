
namespace LionsDen.Models
{
    internal class Employee : Member
    {
        public string JobTitle { get; set; }
        public string YearsOfExperience { get; set; }
        public double HourlySalary { get; set; }
        public string WorkDays { get; set; }
        public double MoneyEarnedLastMonth
        {
            get
            {
                return CalculateMoneyEarnedLastMonth();
            }
        }
        public static double GetHourlySalary(string jobTitle, int yearsOfExp, int workDays)
        {
            double hourlyRate = 0;
            double experienceBonus = 0;
            double workDaysBonus = 0;

            switch (jobTitle)
            {
                case "Coach":
                    hourlyRate = 50;
                    break;
                case "Janitor":
                    hourlyRate = 30;
                    break;
                case "Manager":
                    hourlyRate = 60;
                    break;
                case "Software Developer":
                    hourlyRate = 500;
                    break;
            }
            switch (yearsOfExp)
            {
                case 1:
                    experienceBonus = 3;
                    break;
                case 3:
                    experienceBonus = 10;
                    break;
                case 5:
                    experienceBonus = 15;
                    break;
                case 10:
                    experienceBonus = 25;
                    break;
            }
            switch (workDays)
            {
                case 1:
                    workDaysBonus = 0;
                    break;
                case 2:
                    workDaysBonus = 1;
                    break;
                case 3:
                    workDaysBonus = 2;
                    break;
                case 4:
                    workDaysBonus = 3;
                    break;
                case 5:
                    workDaysBonus = 5;
                    break;
                case 6:
                    workDaysBonus = 7;
                    break;
                case 7:
                    workDaysBonus = 10;
                    break;
            }

            double totalHourlySalary = hourlyRate + experienceBonus + workDaysBonus;
            return totalHourlySalary;
        }


        private double CalculateMoneyEarnedLastMonth()
        {
            return HoursInGymLastMonth * HourlySalary;
        }

    }
}
