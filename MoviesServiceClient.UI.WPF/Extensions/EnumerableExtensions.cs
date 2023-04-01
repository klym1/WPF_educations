using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace MoviesServiceClient.WPF.Extensions
{
    public static class EnumerableExtensions
    {
        public static BindingList<T> ToBindingList<T>(this IEnumerable<T> items)
        {
            return new BindingList<T>(items.ToList());
        }

        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> items)
        {
            return new ObservableCollection<T>(items.ToList());
        }
    }
}