using System;
using MoviesServiceClient.WPF.ContainerConfiguration;
using MoviesServiceClient.WPF.Controls;

namespace MoviesServiceClient.WPF.Navigation
{
    public interface INavigation
    {
        void NavigateTo(ViewName viewName);
        void NavigateTo(ViewName viewName, bool hideSideBar);
        void NavigateTo(ViewName viewName, NavigationContext context, bool hideSideBar);
        void NavigateAway();
        event EventHandler<NavigatedEventArgs> NavigatedBack;
    }
}