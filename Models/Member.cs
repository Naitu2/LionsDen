using LionsDen.Service;
using LionsDen.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LionsDen.Models
{
    internal abstract class Member : INotifyPropertyChanged
    {
        public Member()
        {
            DateOfRegistration = DateTime.Now.Date;
            GymSessions = new ObservableCollection<GymSession>();
            IsLoggedIn = false;
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

        public ObservableCollection<GymSession> GymSessions { get; set; }
        private bool _isLoggedIn;

        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set { _isLoggedIn = value; OnPropertyChanged(); }
        }
        public double HoursInGymLastMonth
        {
            get
            {
                DateTime lastMonth = DateTime.Now.AddMonths(-1);
                DateTime currentDateTime = DateTime.Now;
                double totalHours = GymSessions.Sum(gymSession => gymSession.SessionDuration.TotalHours);

                return totalHours;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
