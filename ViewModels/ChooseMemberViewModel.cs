using LionsDen.Commands;
using LionsDen.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LionsDen.ViewModels
{
    class ChooseMemberViewModel : BaseViewModel
    {
        #region Props
        private NavigationStore _navigationStore;
        public ICommand ReturnNavigateCommand { get; }
        private ICommand _clientButtonCommand;
        public ICommand ClientButtonCommand
        {
            get { return _clientButtonCommand ?? (_clientButtonCommand = new RelayCommand(ExecuteClientButtonCommand)); }
        }
        private ICommand _employeeButtonCommand;
        public ICommand EmployeeButtonCommand
        {
            get { return _employeeButtonCommand ?? (_employeeButtonCommand = new RelayCommand(ExecuteEmployeeButtonCommand)); }
        }

        private object _mainMenuButtonParameter;
        #endregion

        public ChooseMemberViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            ReturnNavigateCommand = new NavigateCommand<BaseViewModel>(navigationStore, () => new MainMenuViewModel(navigationStore));
            _mainMenuButtonParameter = navigationStore.ButtonParameter;
        }
        
        private void ExecuteClientButtonCommand(object parameter)
        {
            switch (_mainMenuButtonParameter)
            {
                case "NewMember":
                    new NavigateCommand<BaseViewModel>(_navigationStore, () => new ClientRegistrationViewModel(_navigationStore)).Execute(parameter);
                    break;

                case "MembersInformation":
                    new NavigateCommand<BaseViewModel>(_navigationStore, () => new ClientInformationViewModel(_navigationStore)).Execute(parameter);
                    break;

                case "MembersAttendance":
                    new NavigateCommand<BaseViewModel>(_navigationStore, () => new ClientAttendanceViewModel(_navigationStore)).Execute(parameter);
                    break;
            }
        }
        private void ExecuteEmployeeButtonCommand(object parameter)
        {
            switch (_mainMenuButtonParameter)
            {
                case "NewMember":
                    new NavigateCommand<BaseViewModel>(_navigationStore, () => new EmployeeRegistrationViewModel(_navigationStore)).Execute(parameter);
                    break;

                case "MembersInformation":
                    new NavigateCommand<BaseViewModel>(_navigationStore, () => new EmployeeInformationViewModel(_navigationStore)).Execute(parameter);

                    break;

                case "MembersAttendance":

                    break;
            }
        }
    }
}
