using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CryptoCurrencyApp.Models;
using CryptoCurrencyApp.Services;
using CryptoCurrencyApp.Services.Currency;

namespace CryptoCurrencyApp.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ICurrencyService _currencyService;

        private IEnumerable<Currency>? _currencies;

        public IEnumerable<Currency>? Currencies
        {
            get => _currencies;
            set
            {
                _currencies = value;
                OnPropertyChanged(nameof(Currencies));
            }
        }

        public RelayCommand LoadCommand { get; set; }

        public HomeViewModel(INavigationService navigationService, ICurrencyService currencyService) : base(navigationService)
        {
            _currencyService = currencyService;
            LoadCommand = new RelayCommand(async () => await Load(), () => true);
        }
        public async Task Load()
        {
            Currencies = await _currencyService.GetTopCoins(10);
        }
    }
}
