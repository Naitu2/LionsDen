using LionsDen.Commands;
using LionsDen.Stores;
using System.Windows.Input;
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
