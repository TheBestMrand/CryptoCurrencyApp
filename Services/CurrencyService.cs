using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CryptoCurrencyApp.Models;

namespace CryptoCurrencyApp.Services
{
    public class CurrencyService
    {
        private readonly HttpClient _httpClient = new();
        private DateTime _lastRequest = DateTime.MinValue;

        public async Task<string> GetCurrencyAsync(string currency)
        {
            var response = await _httpClient.GetAsync($"https://api.coinbase.com/v2/prices/{currency}-USD/spot");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<List<Currency>?> GetTopCurrenciesAsync()
        {
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; fb/1.0)");

            var timeSinceLastRequest = DateTime.Now - _lastRequest;
            if (timeSinceLastRequest.TotalSeconds < 1)
            {
                await Task.Delay(1000 - (int)timeSinceLastRequest.TotalMilliseconds);
            }

            var response = await _httpClient.GetAsync("https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=5&page=1&sparkline=false");
            _lastRequest = DateTime.Now;

            if(response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Currency>>(result);
            }
        
            return null;
        }
    }
}
