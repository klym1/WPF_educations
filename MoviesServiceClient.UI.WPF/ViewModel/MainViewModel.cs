using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MoviesServiceClient.WPF.ContainerConfiguration;
using MoviesServiceClient.WPF.Extensions;
using MoviesServiceClient.WPF.Navigation;

namespace MoviesServiceClient.WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private const string Group1 = "Main";

        private readonly List<MainMenuItem> _mainMenuItems = new List<MainMenuItem>
        {
            new MainMenuItem
            {
                Group = Group1,
                GroupIcon = Application.Current.Resources["DeviceIcon"],
                Title = "Contacts",
                ViewName = ViewName.Contacts.ContactList
            },
        };

        public bool ShowSidebar
        {
            get { return _showSidebar; }
            set
            {
                _showSidebar = value;
                RaisePropertyChanged();
            }
        }

        public List<MainMenuItem> MainMenuItems
        {
            get { return _mainMenuItems; }
        }

        public MainMenuItem SelectedMainMenuItem
        {
            get { return _selectedMainMenuItem; }
            set
            {
                _selectedMainMenuItem = value;
                _navigation.NavigateTo(value.ViewName);
                RaisePropertyChanged();
            }
        }

        public RelayCommand GoToSettingsCommand { get; set; }
        public RelayCommand GoBackCommand { get; private set; }
        public RelayCommand CloseWindowCommand { get; private set; }
        public RelayCommand MaximizeWindowCommand { get; private set; }
        public RelayCommand MinimizeWindowCommand { get; private set; }

        public bool ShowWindowButtons { get; set; }

        public WindowState WindowState
        {
            get { return _windowState; }
            set
            {
                if (_windowState == value)
                    return;

                _windowState = value;

                RaisePropertyChanged("WindowState");
                RaisePropertyChanged("IsWindowMaximized");
            }
        }

        private readonly INavigation _navigation;

        public MainViewModel(INavigation navigation)
        {
            this._navigation = navigation;

            GoToSettingsCommand = new RelayCommand(() =>
            {
                ShowSidebar = false;
                _navigation.NavigateTo(ViewName.Settings, true);
            });

            _navigation.NavigatedBack += (sender, args) =>
            {
                ShowSidebar = args.NeedToUnHideSideBar;
            };

            GoBackCommand = new RelayCommand(() =>
            {
                var frame = Application.Current.MainWindow.GetVisualDescendents().OfType<Frame>().FirstOrDefault(f => f.Name == "RootFrame");
                if (frame == null)
                    return;

                if (frame.CanGoBack)
                    frame.GoBack();
            });

            CloseWindowCommand = new RelayCommand(() => Application.Current.MainWindow.Close(), () => true);
            MinimizeWindowCommand = new RelayCommand(() => WindowState = WindowState.Minimized);
            MaximizeWindowCommand = new RelayCommand(() => WindowState = IsWindowMaximized ? WindowState.Normal : WindowState.Maximized);
            ShowWindowButtons = true;
        }

        public bool IsWindowMaximized
        {
            get { return WindowState == WindowState.Maximized; }
        }

        private MainMenuItem _selectedMainMenuItem;
        private bool _showSidebar;
        private WindowState _windowState;
        
        public void Load()
        {
            ShowSidebar = true;
            SelectedMainMenuItem = MainMenuItems.First();
        }
    }
}