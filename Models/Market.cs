using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoCurrencyApp.Models
{
    public  class Market
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }
    }
}
