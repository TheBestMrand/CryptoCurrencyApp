using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CryptoCurrencyApp.Models;

namespace CryptoCurrencyApp.Services
{
    public class GraphData : IGraphData
    {
        private readonly HttpClient _httpClient;

        public GraphData()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; fb/1.0)");
        }


        public async Task<IEnumerable<OhlcData>> GetOhlcData(string currencyId, int days = 365)
        {
            var url = $"https://api.coingecko.com/api/v3/coins/{currencyId}/ohlc?vs_currency=usd&days={days}";
            var response = await  _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {

                var json = await response.Content.ReadAsStringAsync();

                var ohlcDataList = JsonSerializer.Deserialize<List<List<double>>>(json);

                return ohlcDataList.Select(data => new OhlcData
                {
                    Time = DateTimeOffset.FromUnixTimeMilliseconds((long)data[0]).DateTime,
                    Open = data[1],
                    High = data[2],
                    Low = data[3],
                    Close = data[4]
                });
            }

            throw new Exception($"Failed to fetch data {response.StatusCode}");
        }
    }
}
