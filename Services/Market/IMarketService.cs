using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencyApp.Services.Market
{
    public interface IMarketService
    {
        Task<IEnumerable<Models.Ticker>> GetTickersAsync(string currencyId);
    }
}
