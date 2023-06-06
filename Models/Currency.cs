using System.Text.Json.Serialization;

namespace CryptoCurrencyApp.Models
{
    public class Currency
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("current_price")]
        public decimal CurrentPrice { get; set; }

        //[JsonPropertyName("market_cap")]
        //public long MarketCap { get; set; }

        [JsonPropertyName("total_volume")]
        public decimal Volume { get; set; }

        [JsonPropertyName("price_change_percentage_24h")]
        public decimal PriceChangePercentage24h { get; set; }

        [JsonPropertyName("price_change_24h")]
        public decimal PriceChange24h { get; set; }
    }

}
