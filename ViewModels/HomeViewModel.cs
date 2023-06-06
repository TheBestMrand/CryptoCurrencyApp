using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CryptoCurrencyApp.Models;
using CryptoCurrencyApp.Services;
using CryptoCurrencyApp.Services.Currency;

namespace CryptoCurrencyApp.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ICurrencyService _currencyService;

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                SearchCommand.Execute(null);
            }
        }

        public ObservableCollection<Currency> Currencies
        {
            get => _currencyService.TopCurrencies;
            private set { _currencyService.TopCurrencies = value; OnPropertyChanged(nameof(Currencies));}
        }

        public Currency SelectedCurrency
        {
            get => _currencyService.SelectedCurrency;
            set { _currencyService.SelectedCurrency = value;
                OnPropertyChanged(nameof(SelectedCurrency));
                SelectCurrency(value as Currency);
            }
        }

        public RelayCommand RefreshCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand NavigateToSettingsCommand { get; set; }
        public RelayCommand<Currency> SelectedCurrencyCommand { get; set; }

        public HomeViewModel(INavigationService navigationService, ICurrencyService currencyService) : base(navigationService)
        {
            _currencyService = currencyService;
            RefreshCommand = new RelayCommand(() =>
            {
                _currencyService.GetTopCoins(10);
            }, () => true);

            SearchCommand = new RelayCommand(() =>
            {
                var coins = _currencyService.SearchCoins(SearchText);
                Currencies = new ObservableCollection<Currency>(coins);
            }, () => true);

            NavigateToSettingsCommand = new RelayCommand(() =>
            {
                NavigationService.NavigateTo<SettingsViewModel>();
            }, () => true);

            SelectedCurrencyCommand = new RelayCommand<Currency>(SelectCurrency, (currency) => true);
        }

        private void SelectCurrency(Currency currency)
        {
            _currencyService.SelectedCurrency = currency;
            NavigationService.NavigateTo<DetailsViewModel>();
        }
    }
}
