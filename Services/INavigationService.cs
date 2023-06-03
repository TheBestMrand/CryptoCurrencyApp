using CryptoCurrencyApp.Models;

namespace CryptoCurrencyApp.Services
{
    public interface INavigationService
    {
        ViewModelBase CurrentView { get; }
        void NavigateTo<T>() where T : ViewModelBase;
    }
}
