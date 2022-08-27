using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CleanHouse.Application.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Приведение IEnumerable<T> к ObservableCollection<T>
        /// </summary>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> original) => new ObservableCollection<T>(original);

        /// <summary>
        /// Проверка списка на null и пустоту
        /// </summary>
        public static bool IsNullOrEmpty<T>(this IList<T> list) where T : class => list == null || !list.Any();
        
        /// <summary>
        /// Проверка списка на null и пустоту
        /// </summary>
        public static bool IsNullOrEmpty(this IEnumerable list) => list == null || !list.GetEnumerator().MoveNext();
    }
}