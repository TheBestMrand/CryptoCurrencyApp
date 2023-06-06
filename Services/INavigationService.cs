using CryptoCurrencyApp.Models;

namespace CryptoCurrencyApp.Services
{
    public interface INavigationService
    {
        ViewModelBase CurrentView { get; }
        ViewModelBase SideView { get; }
        void NavigateTo<T>() where T : ViewModelBase;
        void NavigateToSide<T>() where T : ViewModelBase;
    }
}
