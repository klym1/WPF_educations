using System.Windows.Forms;
using DAL;
using Microsoft.Practices.Unity;
using MoviesServiceClient.WPF.ViewModel;

namespace MoviesServiceClient.WPF.ContainerConfiguration.EntitiesRegistrations
{
    public class MainRegistrations : IContainerRegistrations
    {
        public IUnityContainer AddRegistrations(IUnityContainer container)
        {
            return container
                .RegisterType<MainViewModel>(new PerResolveLifetimeManager())
                .RegisterType<MainWindowView>(new PerResolveLifetimeManager())
                .RegisterType(typeof(IGenericRepository<>), typeof(InMemoryGenericRepository<>), new ContainerControlledLifetimeManager() );
        }
    }
}