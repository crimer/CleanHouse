using System.Collections;

namespace CleanHouse.Application.Helpers
{
    /// <summary>
    /// Вспомогательный класс
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Безопасное получение со словаря по ключу 
        /// </summary>
        /// <param name="dict">Словарь</param>
        /// <param name="key">Ключ</param>
        /// <param name="value">Значение</param>
        /// <typeparam name="T">Тип значения</typeparam>
        public static bool TryGet<T>(this IDictionary dict, string key, out T value)
        {
            bool Return(out T outValue)
            {
                outValue = default(T);
                return false;
            }

            if (key == null || dict == null) return Return(out value);
            if (!dict.Contains(key)) return Return(out value);
            var valueObject = dict[key];
            if (valueObject is T variable)
            {
                value = variable;
                return true;
            }

            return Return(out value);
        }
    }
}