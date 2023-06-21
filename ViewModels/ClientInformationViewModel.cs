using LionsDen.Commands;
using LionsDen.Models;
using LionsDen.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LionsDen.ViewModels
{
    internal class ClientInformationViewModel : BaseViewModel
    {
        private NavigationStore _navigationStore;
        public ICommand ReturnNavigateCommand { get; }
        public ICommand GoToClientUpdate { get; }
        private ICommand _goToClientUpdateCommand;
        public ICommand GoToClientUpdateCommand
        {
            get { return _goToClientUpdateCommand ?? (_goToClientUpdateCommand = new RelayCommand(ExecuteGoToClientUpdateCommand)); }
        }
        public ObservableCollection<Client> Clients { get; set;}
        public ClientInformationViewModel(NavigationStore navigationStore)
        {
            ReturnNavigateCommand = new NavigateCommand<BaseViewModel>(navigationStore, () => new ChooseMemberViewModel(navigationStore));
           Clients = new ObservableCollection<Client>(MemberStore.ClientList);
            _navigationStore = navigationStore;
        }
        private void ExecuteGoToClientUpdateCommand(object parametr)
        {
            Client clickedClient = parametr as Client;
            new NavigateCommand<BaseViewModel>(_navigationStore, () => new ClientUpdateViewModel(_navigationStore, clickedClient)).Execute(parametr);
        }

    }

}
