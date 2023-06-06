using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencyApp.Services.Currency
{
    public class CurrencyGeckoSearchStrategy : ICurrencySearchStrategy
    {
        private readonly HttpClient _httpClient;

        public CurrencyGeckoSearchStrategy()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; fb/1.0)");
        }

        public IEnumerable<Models.Currency> Search(string searchTerm, List<Models.Currency> currencies)
        {
            return currencies.Where(currency =>
                currency.Id.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || currency.Symbol.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }
    }
}
