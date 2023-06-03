using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencyApp.Services.Currency
{
    public interface ICurrencyFetchStrategy
    {
        Task<IEnumerable<Models.Currency>?> Fetch();
    }
}
