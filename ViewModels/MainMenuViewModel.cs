using LionsDen.Commands;
using LionsDen.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
namespace LionsDen.ViewModels
{
    internal class MainMenuViewModel : BaseViewModel
    {
        private NavigationStore _navigationStore;
        private ICommand _goToMemberChooseCommand;
        public ICommand GoToMemberChooseCommand
        {
            get { return _goToMemberChooseCommand ?? (_goToMemberChooseCommand = new RelayCommand(ExecuteMyCommand)); }
        }
        public ICommand NavigateCommand { get; }

        public MainMenuViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        private void ExecuteMyCommand(object parameter)
        {
            _navigationStore.ButtonParameter = parameter;
            _navigationStore.CurrentViewModel = new ChooseMemberViewModel(_navigationStore);
        }
    }
}
