using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoCurrencyApp.Services;
using CryptoCurrencyApp.ViewModels;

namespace CryptoCurrencyApp.Models
{
    public abstract class ViewModelBase : ObservableObject
    { 
        private INavigationService _navigationService;

        public INavigationService NavigationService
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
    }
}
