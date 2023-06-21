using LionsDen.Commands;
using LionsDen.Models;
using LionsDen.Service;
using LionsDen.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LionsDen.ViewModels
{
    internal class EmployeeSessionListViewModel : BaseViewModel
    {
        public ICommand ReturnNavigateCommand { get; }
        public ObservableCollection<GymSession> EmployeeSessions { get; set; }
        public EmployeeSessionListViewModel(NavigationStore navigationStore, Employee clickedEmployee)
        {
            ReturnNavigateCommand = new NavigateCommand<BaseViewModel>(navigationStore, () => new EmployeeAttendanceViewModel(navigationStore));
            EmployeeSessions = clickedEmployee.GymSessions;
        }
    }
}
