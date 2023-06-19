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
using System.Windows.Input;

namespace LionsDen.ViewModels
{
    internal class ClientAttendanceViewModel : BaseViewModel
    {
        private GymSession _currentSession;
        private NavigationStore _navigationStore;
        public ICommand ReturnNavigateCommand { get; }
        public ICommand GoToClientAttendanceListCommand { get; }
        public ICommand LogInCommand { get; }
        public ICommand LogOutCommand { get; }
        public ObservableCollection<Client> Clients { get; set; }
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

        public ClientAttendanceViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            ReturnNavigateCommand = new RelayCommand(ExecuteReturnNavigateCommand);
            GoToClientAttendanceListCommand = new RelayCommand(ExecuteGoToClientAttendanceListCommand);
            LogInCommand = new RelayCommand(ExecuteLogInCommand);
            LogOutCommand = new RelayCommand(ExecuteLogOutCommand);


            Clients = new ObservableCollection<Client>(MemberStore.ClientList);
        }

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
            _currentSession = new GymSession { LoginTime = DateTime.Now };
            clickedClient.IsLoggedIn = true;
        }

        public void ExecuteLogOutCommand(object parameter)
        {
            Client clickedClient = parameter as Client;
            _currentSession.LogoutTime = DateTime.Now;
            clickedClient.IsLoggedIn = false;
        }
    }
}
