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
            GoToClientSessionListCommand = new RelayCommand(ExecuteGoToClientSessionListCommand);
            LogInCommand = new RelayCommand(ExecuteLogInCommand);
            LogOutCommand = new RelayCommand(ExecuteLogOutCommand);


            Clients = new ObservableCollection<Client>(MemberStore.ClientList);
        }
        private NavigationStore _navigationStore;
        public ICommand ReturnNavigateCommand { get; }
        public ICommand GoToClientSessionListCommand { get; }
        public ICommand LogInCommand { get; }
        public ICommand LogOutCommand { get; }
        public ObservableCollection<Client> Clients { get; set; }

        private void ExecuteReturnNavigateCommand(object parameter)
        {
            _navigationStore.CurrentViewModel = new ChooseMemberViewModel(_navigationStore);

        }

        private void ExecuteGoToClientSessionListCommand(object parameter)
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
