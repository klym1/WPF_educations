using Microsoft.Practices.Unity;

namespace MoviesServiceClient.WPF.ContainerConfiguration
{
    internal interface IContainerRegistrations
    {
        IUnityContainer AddRegistrations(IUnityContainer container);
    }
}