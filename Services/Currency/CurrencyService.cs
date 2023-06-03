using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CryptoCurrencyApp.Models;

namespace CryptoCurrencyApp.Services.Currency
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyFetchStrategy _currencyFetchStrategy;
        private readonly ICurrencySearchStrategy _currencySearchStrategy;
        private List<Models.Currency> _currencies;

        public CurrencyService(ICurrencyFetchStrategy currencyFetchStrategy,
            ICurrencySearchStrategy currencySearchStrategy)
        {
            _currencyFetchStrategy = currencyFetchStrategy;
            _currencySearchStrategy = currencySearchStrategy;

            UpdateCoints();
        }

        private async void UpdateCoints()
        {
            _currencies = (List<Models.Currency>)(await _currencyFetchStrategy.Fetch());
        }

        public Task<IEnumerable<Models.Currency>> GetTopCoins(int count)
        {
            return Task.FromResult(_currencies.OrderByDescending(x => x.CurrentPrice).Take(count));
        }

        public IEnumerable<Models.Currency> SearchCoins(string query)
        {
            return _currencySearchStrategy.Search(query, _currencies);
        }
    }
}
