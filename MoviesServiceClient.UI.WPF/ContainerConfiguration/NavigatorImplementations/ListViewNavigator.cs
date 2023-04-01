using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.Unity;
using MoviesServiceClient.WPF.Controls;
using MoviesServiceClient.WPF.Extensions;

namespace MoviesServiceClient.WPF.ContainerConfiguration.NavigatorImplementations
{
    internal sealed class ListViewNavigator<T> : IViewNavigator
    {
        private readonly IUnityContainer _container;

        public ListViewNavigator(IUnityContainer container)
        {
            _container = container;
        }

        public void NavigateToView(Navigation.Navigation navigation, NavigationContext context)
        {
            var view = _container.Resolve(typeof (T));
            var viewAsPage = view as Page;
            NavigateToPage(viewAsPage);
        }

        private void NavigateToPage(Page page)
        {
            var frame = MainWindowView.MainFrameStatic;

            if (frame == null)
                throw new ProductsAppException("Frame not found");

            frame.NavigationService.Navigate(page);
        }
    }
}