﻿using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace MoviesServiceClient.WPF.Controls
{
    public partial class FlyoutControl : UserControl
    {
        private object _result = null;

        public static readonly DependencyProperty FlyoutContentProperty =
            DependencyProperty.Register("FlyoutContent", typeof(object), typeof(FlyoutControl), new PropertyMetadata(default(object)));

        public object FlyoutContent
        {
            get { return (object)GetValue(FlyoutContentProperty); }
            set { SetValue(FlyoutContentProperty, value); }
        }

        public static readonly DependencyProperty FlyoutContentTemplateProperty =
            DependencyProperty.Register("FlyoutContentTemplate", typeof(DataTemplate), typeof(FlyoutControl), new PropertyMetadata(default(DataTemplate)));

        public DataTemplate FlyoutContentTemplate
        {
            get { return (DataTemplate)GetValue(FlyoutContentTemplateProperty); }
            set { SetValue(FlyoutContentTemplateProperty, value); }
        }

        public delegate void ClosedEventHandler(object result);
        public event ClosedEventHandler Closed;

        public FlyoutControl()
        {
            InitializeComponent();
        }

        public void Show()
        {
            var mainWindow = Application.Current.MainWindow;
            if (mainWindow.Content == null)
                return;

            var panel = mainWindow.GetVisualDescendent<Panel>(); //mainWindow.Content as Panel;
            if (panel == null)
            {
                return;
            }

            panel.Children.Add(this);
        }

//        public Task<object> ShowAsync()
//        {
//            var tcs = new TaskCompletionSource<object>();
//
//            Show();
//            Closed += (result) => tcs.TrySetResult(result);
//
//            return tcs.Task;
//        }

        public void Close(object result = null)
        {
            _result = result;

            var storyBoard = ((Storyboard) Resources["CloseAnim"]);

            if (storyBoard != null) storyBoard.Begin(this);
        }

        public void CloseNow(object result = null)
        {
            _result = result;

            CloseInternal();
        }

        private void CloseAnim_OnCompleted(object sender, EventArgs e)
        {
            CloseInternal();
        }

        private void CloseInternal()
        {
            var mainWindow = Application.Current.MainWindow;

            if (mainWindow.Content == null)
                return;

            var panel = mainWindow.GetVisualDescendent<Panel>();//mainWindow.Content as Panel;
            if (panel == null)
            {
                return;
            }

            panel.Children.Remove(this);

            if (Closed != null)
                Closed(_result);
        }
    }
}
