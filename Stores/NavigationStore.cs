using LionsDen.ViewModels;
using System;

namespace LionsDen.Stores
{
    class NavigationStore
    {
        public event Action CurrentViewModelChanged;

        private BaseViewModel  _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public Func<BaseViewModel> ViewModelFactory { get; set; }

        public object ButtonParameter { get; set; }
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
