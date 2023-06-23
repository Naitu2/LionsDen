using LionsDen.Commands;
using LionsDen.Models;
using LionsDen.Stores;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Windows.Input;

namespace LionsDen.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        private ObservableCollection<Client> Clients = new ObservableCollection<Client>(MemberStore.ClientList);
        private ObservableCollection<Employee> Employees = new ObservableCollection<Employee>(MemberStore.EmployeeList);
        private ObservableCollection<Coach> Coaches = new ObservableCollection<Coach>(MemberStore.CoachList);
        public ICommand GoHomeCommand { get; }
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        private readonly NavigationStore _navigationStore;
        private ICommand _goToCreditsCommand;
        public ICommand GoToCreditsCommand
        {
            get { return _goToCreditsCommand ?? (_goToCreditsCommand = new RelayCommand(ExecuteGoToCreditsCommand)); }
        }
        private ICommand _headerExitClickCommand;
        public ICommand HeaderExitClickCommand
        {
            get { return _headerExitClickCommand ?? (_headerExitClickCommand = new RelayCommand(GoToExitConformation)); }
        }
        public MainWindowViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            GoHomeCommand = new NavigateCommand<BaseViewModel>(navigationStore, () => new MainMenuViewModel(navigationStore));
        }
        
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        private void ExecuteGoToCreditsCommand(object parameter)
        {
            var navigateCommand = new NavigateCommand<BaseViewModel>(_navigationStore, () => new CreditsViewModel(_navigationStore, CurrentViewModel));
            navigateCommand.Execute(parameter);
        }
        private void GoToExitConformation(object parameter)
        {
            var navigateCommand = new NavigateCommand<BaseViewModel>(_navigationStore, () => new ExitConfirmationViewModel(_navigationStore, CurrentViewModel));
            navigateCommand.Execute(parameter);
        }
    }
}
