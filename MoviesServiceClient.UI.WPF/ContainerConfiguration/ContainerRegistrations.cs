using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Practices.Unity;
using MoviesServiceClient.WPF.Navigation;
using MoviesServiceClient.WPF.ViewModel;

namespace MoviesServiceClient.WPF.ContainerConfiguration
{
    internal sealed class ContainerRegistrations
    {
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public IUnityContainer AddRegistrations(IUnityContainer container)
        {
            return container
                .AddRegistrations(new ByConventionRegistrations().AddRegistrations)
                .RegisterType<INavigation, Navigation.Navigation>(new ContainerControlledLifetimeManager())
                .RegisterType<Func<ViewName, IViewNavigator>>(
                    new InjectionFactory(c =>
                        new Func<ViewName, IViewNavigator>(
                            name => c.Resolve<IViewNavigator>(name))));
        }
    }
}