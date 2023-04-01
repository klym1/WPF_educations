using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Helpers;
using MoviesServiceClient.WPF.ContainerConfiguration;
using MoviesServiceClient.WPF.Controls;
using MoviesServiceClient.WPF.Extensions;

namespace MoviesServiceClient.WPF.Navigation
{
    public class NavigatedEventArgs : EventArgs
    {
        public new static NavigatedEventArgs Empty = new NavigatedEventArgs { NeedToUnHideSideBar = true };

        public bool NeedToUnHideSideBar { get; set; }
    }

    internal sealed class Navigation : INavigation
    {
        private readonly Func<ViewName, IViewNavigator> _viewNavigatorFactory;

        private readonly Stack<bool> showSideBarStack;

        public Navigation(Func<ViewName, IViewNavigator> viewNavigatorFactory)
        {
            _viewNavigatorFactory = viewNavigatorFactory;

            showSideBarStack = new Stack<bool>();
        }

        public void NavigateTo(ViewName viewName)
        {
            NavigateTo(viewName, hideSideBar: false, context: default(NavigationContext));
        }

        public void NavigateTo(ViewName viewName, bool hideSideBar)
        {
            NavigateTo(viewName, hideSideBar: hideSideBar, context: default(NavigationContext));
        }

        public void NavigateTo(ViewName viewName, NavigationContext context, bool hideSideBar)
        {
            showSideBarStack.Push(hideSideBar);

            var viewNavigator = _viewNavigatorFactory(viewName);
            viewNavigator.NavigateToView(this, context);
        }

        public void NavigateAway()
        {
            var frame = MainWindowView.MainFrameStatic;
            if (frame == null)
                return;
            
            if (frame.CanGoBack)
                frame.GoBack();

            var needToUnhideSideBar = showSideBarStack.Pop();

            OnNavigatedBack(needToUnhideSideBar);
        }

        public event EventHandler<NavigatedEventArgs> NavigatedBack;

        private void OnNavigatedBack()
        {
            EventHandler<NavigatedEventArgs> handler = NavigatedBack;
            if (handler != null) handler(this, NavigatedEventArgs.Empty);
        }

        private void OnNavigatedBack(bool needToUnhideSideBar)
        {
            EventHandler<NavigatedEventArgs> handler = NavigatedBack;
            if (handler != null) handler(this, new NavigatedEventArgs { NeedToUnHideSideBar = needToUnhideSideBar });
        }
    }
}