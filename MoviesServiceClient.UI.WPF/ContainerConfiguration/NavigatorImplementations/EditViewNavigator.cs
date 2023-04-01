using System.Windows;
using Microsoft.Practices.Unity;
using MoviesServiceClient.WPF.Controls;

namespace MoviesServiceClient.WPF.ContainerConfiguration.NavigatorImplementations
{
    internal sealed class EditViewNavigator<T> : IViewNavigator
    {
        private readonly IUnityContainer _container;

        public EditViewNavigator(IUnityContainer container)
        {
            _container = container;
        }

        public void NavigateToView(Navigation.Navigation navigation, NavigationContext context)
        {
            var view = _container.Resolve(typeof(T), "Edit", new DependencyOverride(typeof(NavigationContext), context));

            NavigateToPage(view);
        }

        private void NavigateToPage(object page)
        {
            var flyout = new FlyoutControl();
            flyout.FlyoutContent = page;
            flyout.Show();
        }
    }
}