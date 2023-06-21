using LionsDen.Commands;
using LionsDen.Stores;
using System.Windows.Input;

namespace LionsDen.ViewModels
{
    internal class CreditsViewModel : BaseViewModel
    {
        public CreditsViewModel(NavigationStore navigationStore, BaseViewModel prevViewModel)
        {
            ReturnNavigateCommand = new NavigateCommand<BaseViewModel>(navigationStore, () => prevViewModel);
        }
        public ICommand ReturnNavigateCommand { get; }
    }
}
