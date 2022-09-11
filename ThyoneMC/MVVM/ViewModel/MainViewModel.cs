using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThyoneMC.Core;

namespace ThyoneMC.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        // Home
        public HomeViewModel HomeVM { get; set; }
        public RelayCommand HomeViewCommand { get; set; }

        // Mods
        public ServersViewModel ServersVM { get; set; }
        public RelayCommand ServersViewCommand { get; set; }

        // Settings

        public SettingsViewModel SettingsVM { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }

        /** Class */

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            // Setup

            HomeVM = new HomeViewModel();
            ServersVM = new ServersViewModel();
            SettingsVM = new SettingsViewModel();

            // Load

            CurrentView = HomeVM;

            // Command

            HomeViewCommand = new RelayCommand(x =>
            {
                CurrentView = HomeVM;
            });

            ServersViewCommand = new RelayCommand(x =>
            {
                CurrentView = ServersVM;
            });

            SettingsViewCommand = new RelayCommand(x =>
            {
                CurrentView = SettingsVM;
            });
        }
    }
}
