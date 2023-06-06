using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencyApp.Services.Currency
{
    public interface ICurrencySearchStrategy
    {
        IEnumerable<Models.Currency> Search(string searchTerm, List<Models.Currency> currencies);
    }
}
