using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionsDen.Models
{
    internal class Coach : Employee
    {
        public string SpecializedTraining { get; set; }

        public static Coach Parse(Employee employee)
        {
            Coach coach = new Coach
            {
                TaxId = employee.TaxId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Gender = employee.Gender,
                DateOfBirth = employee.DateOfBirth,
                Address = employee.Address,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email,
                JobTitle = employee.JobTitle,
                YearsOfExperience = employee.YearsOfExperience,
                WorkDays = employee.WorkDays,
                HourlySalary = employee.HourlySalary
            };
            return coach;
        }
    }
}
