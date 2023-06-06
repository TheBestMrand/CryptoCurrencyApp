using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CryptoCurrencyApp.Models;

namespace CryptoCurrencyApp.Services.Market
{
    public class MarketService : IMarketService
    {
        private readonly HttpClient _httpClient;

        public MarketService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; fb/1.0)");
        }

        public async Task<IEnumerable<Ticker>> GetTickersAsync(string currencyId)
        {
            var response = await _httpClient.GetAsync($"https://api.coingecko.com/api/v3/coins/{currencyId}/tickers");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var tickers = JsonSerializer.Deserialize<List<Ticker>>(content);

                foreach (var ticker in tickers)
                {
                    ticker.Image = GetMarketLogo(ticker.TradeUrl);
                }

                return tickers;
            }

            throw new Exception($"Failed to fetch data {response.StatusCode}");
        }

        private string GetMarketLogo(string marketUrl)
        {
            var uri = new Uri(marketUrl);
            var faviconUrl = $"{uri.Scheme}://{uri.Host}/favicon.ico";
            return faviconUrl;
        }
    }
}
