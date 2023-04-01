using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using MoviesServiceClient.WPF.Extensions;

namespace MoviesServiceClient.WPF.Controls
{
    public static class VisualTreeExtensions
    {
        private static DependencyObject FindVisualTreeRoot(this DependencyObject d)
        {
            var current = d;
            var dependencyObject = d;
            for (; current != null; current = LogicalTreeHelper.GetParent(current))
            {
                dependencyObject = current;
                if (current is Visual || current is Visual3D)
                    break;
            }
            return dependencyObject;
        }

        public static IEnumerable<FrameworkElement> GetVisualDescendents(this FrameworkElement root)
        {

            var toDo = new Queue<IEnumerable<FrameworkElement>>();

            toDo.Enqueue(root.GetVisualChildren());
            while (toDo.Count > 0)
            {
                IEnumerable<FrameworkElement> children = toDo.Dequeue();
                foreach (FrameworkElement child in children)
                {
                    yield return child;
                    toDo.Enqueue(child.GetVisualChildren());
                }
            }

        }

        public static T GetVisualAncestor<T>(this DependencyObject d) where T : class
        {
            for (DependencyObject parent = VisualTreeHelper.GetParent(d.FindVisualTreeRoot()); parent != null; parent = VisualTreeHelper.GetParent(parent))
            {
                T obj = parent as T;
                if (obj != null)
                    return obj;
            }
            return default(T);
        }

        public static DependencyObject GetVisualAncestor(this DependencyObject d, Type type)
        {
            for (DependencyObject parent = VisualTreeHelper.GetParent(d.FindVisualTreeRoot()); parent != null && type != (Type)null; parent = VisualTreeHelper.GetParent(parent))
            {
                if (parent.GetType() == type || parent.GetType().IsSubclassOf(type))
                    return parent;
            }
            return null;
        }

        /// <summary>
        /// find the visual ancestor by type and go through the visual tree until the given itemsControl will be found
        /// 
        /// </summary>
        public static DependencyObject GetVisualAncestor(this DependencyObject d, Type type, ItemsControl itemsControl)
        {
            var parent = VisualTreeHelper.GetParent(d.FindVisualTreeRoot());
            DependencyObject dependencyObject = null;
            for (; parent != null && type != (Type)null && parent != itemsControl; parent = VisualTreeHelper.GetParent(parent))
            {
                if (parent.GetType() == type || parent.GetType().IsSubclassOf(type))
                    dependencyObject = parent;
            }
            return dependencyObject;
        }
        
        public static IEnumerable<T> GetVisualDescendents<T>(this DependencyObject d) where T : DependencyObject
        {
            int childCount = VisualTreeHelper.GetChildrenCount(d);
            for (int n = 0; n < childCount; ++n)
            {
                DependencyObject child = VisualTreeHelper.GetChild(d, n);
                if (child is T)
                    yield return (T)child;
                foreach (var obj in child.GetVisualDescendents<T>())
                    yield return obj;
            }
        }

        public static T GetVisualDescendent<T>(this DependencyObject d) where T : DependencyObject
        {
            return d.GetVisualDescendents<T>().FirstOrDefault();
        }
    }
}