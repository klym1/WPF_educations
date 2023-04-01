using System.Diagnostics.CodeAnalysis;
using Microsoft.Practices.Unity;
using MoviesServiceClient.WPF.ContainerConfiguration;

namespace MoviesServiceClient.WPF
{
    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable",
        Justification = "Bootstrap and its container exist during entire app lifetime and are destroyed only when app exits")]
    internal class Bootstrap
    {
        private readonly IUnityContainer _unityContainer;

        public Bootstrap()
        {
            _unityContainer = new UnityContainer();
            ConfigureContainer();
        }
        
        private void ConfigureContainer()
        {
            _unityContainer.AddRegistrations(new ContainerRegistrations().AddRegistrations);
        }

        public void Run()
        {
            _unityContainer.Resolve<MainWindowView>().Show();
        }
    }
}
