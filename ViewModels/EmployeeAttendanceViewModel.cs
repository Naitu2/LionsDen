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
    internal class EmployeeAttendanceViewModel : BaseViewModel
    {
        public EmployeeAttendanceViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            ReturnNavigateCommand = new RelayCommand(ExecuteReturnNavigateCommand);
           /* GoTClientSessionListCommand = new RelayCommand(ExecuteGoTClientSessionListCommand);*/
            LogInCommand = new RelayCommand(ExecuteLogInCommand);
            LogOutCommand = new RelayCommand(ExecuteLogOutCommand);


            Employees = new ObservableCollection<Employee>(MemberStore.EmployeeList);
        }
        private NavigationStore _navigationStore;
        public ICommand ReturnNavigateCommand { get; }
       /* public ICommand GoTClientSessionListCommand { get; }*/
        public ICommand LogInCommand { get; }
        public ICommand LogOutCommand { get; }
        public ObservableCollection<Employee> Employees { get; set; }

        private void ExecuteReturnNavigateCommand(object parameter)
        {
            _navigationStore.CurrentViewModel = new ChooseMemberViewModel(_navigationStore);

        }

        private void ExecuteGoToEmployeeSessionListCommand(object parameter)
        {
            Client clickedClient = parameter as Client;
          /*  _navigationStore.CurrentViewModel = new EmployeeSessionListViewModel(_navigationStore, clickedClient);*/
        }

        public void ExecuteLogInCommand(object parameter)
        {
            Employee clickedEmployee = parameter as Employee;
            GymSession.StartSession(clickedEmployee);
        }

        public void ExecuteLogOutCommand(object parameter)
        {
            Employee clickedEmployee = parameter as Employee;
            GymSession.EndSession(clickedEmployee);
        }
    }
}
