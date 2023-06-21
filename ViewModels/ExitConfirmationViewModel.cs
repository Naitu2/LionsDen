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
    internal class ExitConfirmationViewModel : BaseViewModel
    {
        private NavigationStore _navigationStore;
        private BaseViewModel _prevViewModel;

        public ICommand ExitCommand { get; }
        public ICommand GoBackCommand { get; }

        public ExitConfirmationViewModel(NavigationStore navigationStore, BaseViewModel prevViewModel)
        {
            _navigationStore = navigationStore;
            _prevViewModel = prevViewModel;
            ExitCommand = new RelayCommand(ExitCommandExecute);
            GoBackCommand = new RelayCommand(GoBackCommandExecute);
        }
        private void ExitCommandExecute(object parameter)
        {
            Application.Current.Shutdown();
        }

        private void GoBackCommandExecute(object parameter)
        {
            _navigationStore.CurrentViewModel = _prevViewModel;
        }
    }
}
