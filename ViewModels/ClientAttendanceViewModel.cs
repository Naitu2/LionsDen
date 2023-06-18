using LionsDen.Commands;
using LionsDen.Models;
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
        private NavigationStore _navigationStore;
        public ICommand ReturnNavigateCommand { get; }
        public ICommand GoToClientAttendanceListCommand { get; }
        public ObservableCollection<Client> Clients { get; set; }

        public ClientAttendanceViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            ReturnNavigateCommand = new RelayCommand(ExecuteReturnNavigateCommand);
            GoToClientAttendanceListCommand = new RelayCommand(ExecuteGoToClientAttendanceListCommand);

            Clients = new ObservableCollection<Client>(MemberStore.ClientList);
        }

        private void ExecuteReturnNavigateCommand(object parameter)
        {
            _navigationStore.CurrentViewModel = new ChooseMemberViewModel(_navigationStore);
        }

        private void ExecuteGoToClientAttendanceListCommand(object parameter)
        {
            Client clickedClient = parameter as Client;
            _navigationStore.CurrentViewModel = new ClientAttendanceListViewModel(_navigationStore, clickedClient);
        }

    }
}
