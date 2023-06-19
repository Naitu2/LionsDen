using LionsDen.Commands;
using LionsDen.Models;
using LionsDen.Service;
using LionsDen.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LionsDen.ViewModels
{
    internal class ClientAttendanceViewModel : BaseViewModel
    {
        public ClientAttendanceViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            ReturnNavigateCommand = new RelayCommand(ExecuteReturnNavigateCommand);
            GoToClientAttendanceListCommand = new RelayCommand(ExecuteGoToClientAttendanceListCommand);
            LogInCommand = new RelayCommand(ExecuteLogInCommand);
            LogOutCommand = new RelayCommand(ExecuteLogOutCommand);


            Clients = new ObservableCollection<Client>(MemberStore.ClientList);

     /*       UpdateButtonStates();*/
        }
        private NavigationStore _navigationStore;
        public ICommand ReturnNavigateCommand { get; }
        public ICommand GoToClientAttendanceListCommand { get; }
        public ICommand LogInCommand { get; }
        public ICommand LogOutCommand { get; }
        public ObservableCollection<Client> Clients { get; set; }

        public string LogOutCursor;
        private bool _logInEnabled;
        public bool LogInEnabled
        {
            get { return _logInEnabled; }
            set
            {
                _logInEnabled = value;
                OnPropertyChanged(nameof(LogInEnabled));
                LogOutEnabled = !value;
                OnPropertyChanged(nameof(LogOutEnabled));
            }
        }

        private bool _logOutEnabled;

        public bool LogOutEnabled
        {
            get { return _logOutEnabled; }
            set
            {
                _logOutEnabled = value;
                LogInEnabled = !value;
                OnPropertyChanged(nameof(LogOutEnabled));
                OnPropertyChanged(nameof(LogInEnabled));
            }
        }

        public double HoursInGymLastMonth
        {
            get
            {
                DateTime lastMonth = DateTime.Now.AddMonths(-1);
                DateTime currentDateTime = DateTime.Now;

                double totalHours = Clients.Sum(client =>
                {
                    double clientTotalHours = client.GymSessions
                        .Where(session => session.LoginTime > lastMonth && session.LogoutTime <= currentDateTime)
                        .Sum(session => session.SessionDuration.TotalHours);

                    return clientTotalHours;
                });

                return totalHours;
            }
        }

        /*public void UpdateButtonStates()
        {
            foreach (Client client in Clients)
            {
                bool loggedIn = client.GymSessions.Any(session => session.LogoutTime == null);
                client.LogInEnabled = !loggedIn;
                client.LogOutEnabled = loggedIn;
            }
        }*/

        private void ExecuteReturnNavigateCommand(object parameter)
        {
            _navigationStore.CurrentViewModel = new ChooseMemberViewModel(_navigationStore);

        }

        private void ExecuteGoToClientAttendanceListCommand(object parameter)
        {
            Client clickedClient = parameter as Client;
            _navigationStore.CurrentViewModel = new ClientSessionListViewModel(_navigationStore, clickedClient);
        }

        public void ExecuteLogInCommand(object parameter)
        {
            Client clickedClient = parameter as Client;
            GymSession.StartSession(clickedClient);
        }

        public void ExecuteLogOutCommand(object parameter)
        {
            Client clickedClient = parameter as Client;
            GymSession.EndSession(clickedClient);
        }
    }
}
