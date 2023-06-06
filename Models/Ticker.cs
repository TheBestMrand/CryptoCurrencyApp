using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoCurrencyApp.Models
{
    public class Ticker
    {
        [JsonPropertyName("market")]
        public Market Market { get; set; }
        [JsonPropertyName("last")]
        public double Last { get; set; }
        [JsonPropertyName("volume")]
        public decimal Volume { get; set; }
        [JsonPropertyName("trust_score")]
        public string TrustScore { get; set; }
        [JsonPropertyName("trade_url")]
        public string TradeUrl { get; set; }
        [JsonPropertyName("image")]
        public string Image { get; set; }
    }
}
