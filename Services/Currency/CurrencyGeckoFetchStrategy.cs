using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoCurrencyApp.Services.Currency
{
    public class CurrencyGeckoFetchStrategy : ICurrencyFetchStrategy
    {
        private readonly HttpClient _httpClient;

        public CurrencyGeckoFetchStrategy()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; fb/1.0)");
        }

        public async Task<IEnumerable<Models.Currency>?> Fetch()
        {
            var responce = await _httpClient.GetAsync("https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=100&page=1&sparkline=false");

            if(responce.IsSuccessStatusCode)
            {
                var result = await responce.Content.ReadAsStringAsync();
                var currencies = System.Text.Json.JsonSerializer.Deserialize<List<Models.Currency>>(result);
                return currencies;
            }

            throw new Exception("Error fetching currencies");
        }
    }
}
