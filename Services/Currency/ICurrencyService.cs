using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencyApp.Services.Currency
{
    public interface ICurrencyService
    {
        void GetTopCoins(int count);
        IEnumerable<Models.Currency> SearchCoins(string query);
        void SetRefreshInterval(TimeSpan interval);
        ObservableCollection<Models.Currency> TopCurrencies { get; set; }
        public Models.Currency SelectedCurrency { get; set;}
        event Action SelectedCurrencyChanged;
    }
}
