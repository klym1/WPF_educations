using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.Unity;
using MoviesServiceClient.WPF.Controls;
using MoviesServiceClient.WPF.Extensions;

namespace MoviesServiceClient.WPF.ContainerConfiguration.NavigatorImplementations
{
    internal sealed class AddViewNavigator<T>: IViewNavigator
    {
        private readonly IUnityContainer _container;

        public AddViewNavigator(IUnityContainer container)
        {
            _container = container;
        }   

        public void NavigateToView(Navigation.Navigation navigation, NavigationContext context)
        {
            var view = _container.Resolve(typeof(T), "Add");
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