using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Practices.Unity;

namespace MoviesServiceClient.WPF.ContainerConfiguration
{
    internal static class UnityContainerExtensions
    {
        public static IUnityContainer AddRegistrations(
            this IUnityContainer container,
            Func<IUnityContainer, IUnityContainer> addRegistrations)
        {
            return addRegistrations(container);
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope",
            Justification = "No need to dispose LifetimeManagers")]
        public static IUnityContainer RegisterViewNavigator<TViewNavigator>(
            this IUnityContainer container,
            ViewName viewName)
            where TViewNavigator : IViewNavigator
        {
            return container.RegisterType<IViewNavigator, TViewNavigator>(
                viewName,
                new ContainerControlledLifetimeManager());
        }
    }
}