using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using MoviesServiceClient.WPF.Navigation;

namespace MoviesServiceClient.WPF.Settings
{
    public class SettingsViewModel
    {
        private readonly INavigation _navigation;
        public RelayCommand GoAwayCommand { get; private set; }

        public SettingsViewModel(INavigation navigation)
        {
            _navigation = navigation;
            GoAwayCommand = new RelayCommand(GoAwayAction);
        }

        private void GoAwayAction()
        {
            _navigation.NavigateAway();
        }
    }
}
