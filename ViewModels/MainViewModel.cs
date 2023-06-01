using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CryptoCurrencyApp.Models;
using CryptoCurrencyApp.Services;

namespace CryptoCurrencyApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly CurrencyService _service;
        private ObservableCollection<Currency> _topCurrencies;

        public ObservableCollection<Currency> TopCurrencies
        {
            get => _topCurrencies;
            set => SetField(ref _topCurrencies, value);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainViewModel(CurrencyService service)
        {
            _service = service;
        }

        public async Task LoadData()
        {
            var currencies = await _service.GetTopCurrenciesAsync();
            TopCurrencies = new ObservableCollection<Currency>(currencies);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
