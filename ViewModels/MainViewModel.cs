using CommunityToolkit.Mvvm.Input;
using CryptoCurrencyApp.Models;
using CryptoCurrencyApp.Services;

namespace CryptoCurrencyApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand NavigateToHomeCommand { get; set; }

        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            NavigateToHomeCommand = new RelayCommand(() =>
            {
                NavigationService.NavigateToSide<HomeViewModel>();
            }, () => true);

            NavigateToHomeCommand.Execute(true);
        }
    }
}
