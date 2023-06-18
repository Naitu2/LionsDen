using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LionsDen.Service
{
    class Validation
    {
        public static bool IsValidDouble(string stringValue)
        {

            if (double.TryParse(stringValue, out double validDouble) && validDouble > 0)
            {
                return true;
            }
            return false;
        }
        public static bool IsValidPercents(string stringValue)
        {
            if (int.TryParse(stringValue, out int validInt) && validInt >= 0 && validInt <= 100)
            {
                return true;
            }
            return false;
        }
        public static bool IsValidTaxId(string taxId)
        {
            Regex regex = new Regex(@"^\d{9}$");
            if (regex.IsMatch(taxId))
            {
                return true;
            }
            return false;
        }
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            Regex regex = new Regex(@"^0\d{9}$");
            if (regex.IsMatch(phoneNumber))
            {
                return true;
            }
            return false;
        }
        public static bool IsValidEmail(string email)
        {
            Regex regex = new Regex(@"^[\w.%+-]+@[\w.-]+\.[A-Za-z]{2,}$");
            if (regex.IsMatch(email))
            {
                return true;
            }
            return false;
        }
        public static bool IsValidDateOfBirth(DateTime? dateOfBirth)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dateOfBirth.Value.Year;

            if (age >= 0 && age < 120)
            {
                return dateOfBirth < today;
            }

            return false;
        }

    }
}
