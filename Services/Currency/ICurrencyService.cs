using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencyApp.Services.Currency
{
    public interface ICurrencyService
    {
        Task<IEnumerable<Models.Currency>> GetTopCoins(int count);
        IEnumerable<Models.Currency> SearchCoins(string query);
    }
}
