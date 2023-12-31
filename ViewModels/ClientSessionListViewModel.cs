﻿using LionsDen.Commands;
using LionsDen.Models;
using LionsDen.Service;
using LionsDen.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LionsDen.ViewModels
{
    class ClientSessionListViewModel : BaseViewModel
    {
        public ICommand ReturnNavigateCommand { get; }
        public ObservableCollection<GymSession> ClientSessions { get; set; }
        public ClientSessionListViewModel(NavigationStore navigationStore, Client clickedClient)
        {
            ReturnNavigateCommand = new NavigateCommand<BaseViewModel>(navigationStore, () => new ClientAttendanceViewModel(navigationStore));
            ClientSessions = clickedClient.GymSessions;
        }
    }
}
