using System;
using System.Windows;
using CryptoCurrencyApp.Services;
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
            services.AddSingleton<CurrencyService>();
            services.AddTransient<MainViewModel>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var viewModel = _serviceProvider.GetService<MainViewModel>();
            var mainWindow = new MainWindow();
        }
    }
}
