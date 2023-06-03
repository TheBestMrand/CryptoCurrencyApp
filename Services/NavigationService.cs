using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CryptoCurrencyApp.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoCurrencyApp.Services
{
    public class NavigationService : ObservableObject, INavigationService
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentView
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        private readonly Func<Type, ViewModelBase> _viewModelPredicate;

        public NavigationService(Func<Type, ViewModelBase> viewModelPredicate)
        {
            _viewModelPredicate = viewModelPredicate;
        }

        /// <summary>
        /// Navigation method to navigate to a view model
        /// </summary>
        /// <typeparam name="T">Desired view model to navigate to</typeparam>
        public void NavigateTo<T>() where T : ViewModelBase
        {
            CurrentView = _viewModelPredicate.Invoke(typeof(T));
        }
    }
}
