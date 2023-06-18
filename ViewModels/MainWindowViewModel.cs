using LionsDen.Commands;
using LionsDen.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LionsDen.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        public ICommand GoHomeCommand { get; }
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        private readonly NavigationStore _navigationStore;
        private ICommand _headerCreditsClickCommand;
        public ICommand HeaderCreditsClickCommand
        {
            get { return _headerCreditsClickCommand ?? (_headerCreditsClickCommand = new RelayCommand(ShowCredits)); }
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
        private void ShowCredits(object parameter)
        {
            MessageBox.Show("Zhopa");
        }
        private void GoToExitConformation(object parameter)
        {
            var navigateCommand = new NavigateCommand<BaseViewModel>(_navigationStore, () => new ExitConfirmationViewModel(_navigationStore, CurrentViewModel));
            navigateCommand.Execute(parameter);
        }
    }
}
