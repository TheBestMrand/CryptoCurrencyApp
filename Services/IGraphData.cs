using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoCurrencyApp.Models;

namespace CryptoCurrencyApp.Services
{
    public interface IGraphData
    {
        public Task<IEnumerable<OhlcData>> GetOhlcData(string currencyId, int days);
    }
}
