using System.Windows;
using System.Windows.Controls;

namespace MoviesServiceClient.WPF.Settings
{
    public partial class SettingsView
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        public SettingsView(SettingsViewModel settingsViewModel) : this()
        {
            DataContext = settingsViewModel;
        }
    }
}