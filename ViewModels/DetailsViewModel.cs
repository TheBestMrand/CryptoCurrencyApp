using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CryptoCurrencyApp.Models;
using CryptoCurrencyApp.Services;
using CryptoCurrencyApp.Services.Currency;
using CryptoCurrencyApp.Services.Market;

namespace CryptoCurrencyApp.ViewModels
{
    public class DetailsViewModel : ViewModelBase
    {
        private readonly ICurrencyService _currencyService;
        private readonly IMarketService _marketService;

        public ObservableCollection<Ticker> Tickers { get; set; }

        public Currency SelectedCurrency => _currencyService.SelectedCurrency;

        public RelayCommand<Ticker> OpenUrlCommand;

        public DetailsViewModel(INavigationService navigationService, ICurrencyService currencyService, IMarketService marketService) : base(navigationService)
        {
            _currencyService = currencyService;
            _marketService = marketService;
            Tickers = new ObservableCollection<Ticker>();
            GetTickers();
            OpenUrlCommand = new RelayCommand<Ticker>(OpenUrl);
        }

        private void OpenUrl(Ticker? ticker)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = ticker.TradeUrl,
                UseShellExecute = true
            });
        }

        public void GetTickers()
        {
            Tickers = new ObservableCollection<Ticker>(_marketService.GetTickersAsync(SelectedCurrency.Id).Result);
        }
    }
}
