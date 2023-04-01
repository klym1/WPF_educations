using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using DAL;
using MoviesServiceClient.WPF.Extensions;
using MoviesServiceClient.WPF.ViewModel;

namespace MoviesServiceClient.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView
    {
        public MainWindowView(MainViewModel mainWindowViewModel)
        {
            InitializeComponent();
            
            Loaded += (sender, args) => mainWindowViewModel.Load();

            DataContext = mainWindowViewModel;
        }

        public static Frame MainFrameStatic
        {
            get
            {

                var all = Application.Current.MainWindow.GetVisualDescendents().OfType<Frame>();

                var names = all.Select(it => it.Name).ToList();

                var first = all.FirstOrDefault();

                return first;
            }
        }

        private void ResizeGripMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
//              todo
            }
        }

        private void MainWindowView_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && e.GetPosition(this).Y < 30)
            {
                if (WindowState == WindowState.Maximized)
                {
                    Top = -e.GetPosition(this).Y / 2;
                    WindowState = WindowState.Normal;
                }
                else
                {
                    DragMove();
                }
            }
        }
    }
}
