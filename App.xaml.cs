using System;
using System.Windows;
using CryptoCurrencyApp.Models;
using CryptoCurrencyApp.Services;
using CryptoCurrencyApp.Services.Currency;
using CryptoCurrencyApp.Services.Market;
using CryptoCurrencyApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoCurrencyApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            #region ViewModels
            services.AddSingleton(provider => new MainWindow()
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<SettingsViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<DetailsViewModel>();
            #endregion

            #region Servies
            services.AddSingleton<CurrencyService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<Func<Type, ViewModelBase>>(
                serviceProvider => 
                    viewModel => (serviceProvider.GetRequiredService(viewModel) as ViewModelBase)!);
            services.AddSingleton<ICurrencyFetchStrategy, CurrencyGeckoFetchStrategy>();
            services.AddSingleton<ICurrencySearchStrategy, CurrencyGeckoSearchStrategy>();
            services.AddSingleton<ICurrencyService, CurrencyService>();
            services.AddSingleton<IMarketService, MarketService>();
            #endregion
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var viewModel = _serviceProvider.GetRequiredService<MainWindow>();
            viewModel.Show();
            base.OnStartup(e);
        }
    }
}
