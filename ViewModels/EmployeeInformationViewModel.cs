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
    internal class EmployeeInformationViewModel : BaseViewModel
    {
        private NavigationStore _navigationStore;
        public ICommand ReturnNavigateCommand { get; }
        private ICommand _goToEmployeeUpdateCommand;
        public ICommand GoToEmployeeUpdate
        {
            get { return _goToEmployeeUpdateCommand ?? (_goToEmployeeUpdateCommand = new RelayCommand(ExecuteGoToEmployeeUpdateCommand)); }
        }
        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Coach> Coaches { get; set; }
        public EmployeeInformationViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            ReturnNavigateCommand = new NavigateCommand<BaseViewModel>(navigationStore, () => new ChooseMemberViewModel(navigationStore));
            Employees = new ObservableCollection<Employee>(MemberStore.EmployeeList);
            Coaches = new ObservableCollection<Coach>(MemberStore.CoachList);
        }
        private void ExecuteGoToEmployeeUpdateCommand(object parameter)
        {
            if (parameter is Coach)
            {
                Coach clickedCoach = parameter as Coach;
                new NavigateCommand<BaseViewModel>(_navigationStore, () => new EmployeeUpdateViewModel(_navigationStore, clickedCoach)).Execute(parameter);
            }
            else
            {
                Employee clickedEmployee = parameter as Employee;
                new NavigateCommand<BaseViewModel>(_navigationStore, () => new EmployeeUpdateViewModel(_navigationStore, clickedEmployee)).Execute(parameter);
            }
        }
    }
}
