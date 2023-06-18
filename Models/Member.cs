using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionsDen.Models
{
    internal abstract class Member
    {
        public Member()
        {
            DateOfRegistration = DateTime.Now.Date;
        }

        public string TaxId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfRegistration { get; set; }
    }
}
