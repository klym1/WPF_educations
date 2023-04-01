using Microsoft.Practices.Unity;
using MoviesServiceClient.WPF.ContainerConfiguration.NavigatorImplementations;
using MoviesServiceClient.WPF.Settings;

namespace MoviesServiceClient.WPF.ContainerConfiguration.EntitiesRegistrations
{
    public class SettingsContainerRegistrations : IContainerRegistrations
    {
        public IUnityContainer AddRegistrations(IUnityContainer container)
        {
            return container
                .AddRegistrations(RegisterList);
        }

        private static IUnityContainer RegisterList(IUnityContainer container)
        {
            return container
                .RegisterViewNavigator<ListViewNavigator<SettingsView>>(ViewName.Settings);
        }
    }
}