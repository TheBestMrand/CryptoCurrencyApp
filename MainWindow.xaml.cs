using System.Linq;
using System.Windows;
using CryptoCurrencyApp.Services;
using CryptoCurrencyApp.ViewModels;
using CryptoCurrencyApp.Views;

namespace CryptoCurrencyApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel? ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var service = new CurrencyService();
            ViewModel = new MainViewModel(service);
            DataContext = ViewModel;
            await ViewModel.LoadData();
            MessageBox.Show(string.Join("\n",ViewModel.TopCurrencies));
        }
    }
}
