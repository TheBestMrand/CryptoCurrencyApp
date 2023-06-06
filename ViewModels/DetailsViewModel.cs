using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CryptoCurrencyApp.Models;
using CryptoCurrencyApp.Services;
using CryptoCurrencyApp.Services.Currency;
using CryptoCurrencyApp.Services.Market;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace CryptoCurrencyApp.ViewModels
{
    public class DetailsViewModel : ViewModelBase
    {
        private readonly ICurrencyService _currencyService;
        private readonly IMarketService _marketService;
        private readonly IGraphData _graphData;

        private IEnumerable<OhlcData> _ohlcData;

        public ObservableCollection<Ticker> Tickers { get; set; }

        public Currency SelectedCurrency => _currencyService.SelectedCurrency;

        public SeriesCollection OhlcSeriesCollection { get; set; }

        public Func<double, string> PriceFormatter { get; set; } = value => value.ToString("C");
        public Func<double, string> DataFormatter { get; set; }

        public RelayCommand<Ticker> OpenUrlCommand;
        public RelayCommand<string> GetGraphDataForDaysCommand { get; set; }

        public DetailsViewModel(INavigationService navigationService, ICurrencyService currencyService, IMarketService marketService, IGraphData graphData) : base(navigationService)
        {
            _currencyService = currencyService;
            _marketService = marketService;
            _graphData = graphData;
            Tickers = new ObservableCollection<Ticker>();
            //GetTickers();
            //OpenUrlCommand = new RelayCommand<Ticker>(OpenUrl);
            _currencyService.SelectedCurrencyChanged += RefreshData;
            GetGraphDataForDaysCommand = new RelayCommand<string>(GetGraphDataForDays);
        }

        private void RefreshData()
        {
            OnPropertyChanged(nameof(SelectedCurrency));
        }

        private void OpenUrl(Ticker? ticker)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = ticker.TradeUrl,
                UseShellExecute = true
            });
        }

        public async void GetTickers()
        {
            Tickers = new ObservableCollection<Ticker>(await _marketService.GetTickersAsync(SelectedCurrency.Id));
        }

        public void CacheGraphData()
        {
            _ohlcData = _graphData.GetOhlcData(SelectedCurrency.Id, 30).Result;

            var ohlcSeries = new OhlcSeries
            {
                Values = new ChartValues<OhlcPoint>(_ohlcData.Select(x => new OhlcPoint(x.Open, x.High, x.Low, x.Close)))
            };

            OhlcSeriesCollection = new SeriesCollection
            {
                ohlcSeries
            };

            DataFormatter = value => new DateTime((long)value).ToString("d");
        }

        public void GetGraphDataForDays(string daysStr)
        {
            int days = int.Parse(daysStr);
            if (_ohlcData is null)
            {
                CacheGraphData();
            }
            var correctDays = _ohlcData.Take(days);
            var ohlcSeries = new OhlcSeries
            {
                Values = new ChartValues<OhlcPoint>(_ohlcData.Select(x => new OhlcPoint(x.Open, x.High, x.Low, x.Close)))
            };
            OhlcSeriesCollection = new SeriesCollection
            {
                ohlcSeries
            };
            DataFormatter = value => new DateTime((long)value).ToString("d");
        }
    }
}
