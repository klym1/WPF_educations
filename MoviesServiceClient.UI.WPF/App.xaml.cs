using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;
using MoviesServiceClient.WPF.Controls;

namespace MoviesServiceClient.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private readonly Bootstrap _bootstrap;

        public App()
        {
            _bootstrap = new Bootstrap();



            Startup += (sender, args) => _bootstrap.Run();
        }

        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);


            Dispatcher.Invoke(() =>
            {
                e.Handled = true;

                var flyout = new FlyoutControl();
               // flyout.FlyoutContent = new CommonErrorView();
//                var restart = (bool)await flyout.ShowAsync();
               
                Shutdown();
            });
        }
    }
}
