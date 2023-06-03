using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoCurrencyApp.Models;
using CryptoCurrencyApp.Services;

namespace CryptoCurrencyApp.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
