using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using CryptoCurrencyApp.Models;

namespace CryptoCurrencyApp.Services.Currency
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyFetchStrategy _currencyFetchStrategy;
        private readonly ICurrencySearchStrategy _currencySearchStrategy;
        private List<Models.Currency> _currencies;


        private Timer _timer;
        private TimeSpan _refreshInterval;

        public ObservableCollection<Models.Currency> TopCurrencies { get; set; }
        public Models.Currency SelectedCurrency { get; set; }

        public CurrencyService(ICurrencyFetchStrategy currencyFetchStrategy,
            ICurrencySearchStrategy currencySearchStrategy)
        {
            _currencyFetchStrategy = currencyFetchStrategy;
            _currencySearchStrategy = currencySearchStrategy;
            _refreshInterval = TimeSpan.FromMinutes(10);

            _timer = new Timer(UpdateCurrency, null, TimeSpan.Zero, _refreshInterval);
            UpdateCurrency();
        }

        public async void UpdateCurrency(object? state = null)
        {
            _currencies = (List<Models.Currency>)(await _currencyFetchStrategy.Fetch());
            GetTopCoins();
        }

        public void GetTopCoins(int count = 10)
        {
            if(_currencies is not null)
                TopCurrencies = new ObservableCollection<Models.Currency>(_currencies.Take(count));
        }

        public IEnumerable<Models.Currency> SearchCoins(string query)
        {
            return _currencySearchStrategy.Search(query, _currencies);
        }

        public void SetRefreshInterval(TimeSpan interval)
        {
            _refreshInterval = interval;
            _timer.Change(TimeSpan.Zero, _refreshInterval);
        }
    }
}
