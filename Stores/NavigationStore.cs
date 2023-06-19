using LionsDen.Service;
using LionsDen.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void UpdateCurrentViewModel ()
        {
         
        }
    }
}
