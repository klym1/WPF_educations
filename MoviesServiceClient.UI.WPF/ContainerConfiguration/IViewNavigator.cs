using MoviesServiceClient.WPF.Controls;

namespace MoviesServiceClient.WPF.ContainerConfiguration
{
    internal interface IViewNavigator
    {
        void NavigateToView(Navigation.Navigation navigation, NavigationContext context);
    }
}