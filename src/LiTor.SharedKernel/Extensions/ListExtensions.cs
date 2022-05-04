namespace System.Collections.Generic
{
    /// <summary>
    /// Extension methods for <see cref="IList"/>
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Inserts element on the beginning of the list
        /// </summary>
        public static void AddFirst<T>(this IList<T> source, T item)
        {
            source.Insert(0, item);
        }

        /// <summary>
        /// Appends items to an existing collection if condition is satisfied
        /// </summary>
        public static void AddRangeIf<T>(this List<T> source, bool condition, List<T> items)
        {
            if (condition)
            {
                source.AddRange(items);
            }
        }

        /// <summary>
        /// Appends item to an existing collection if condition is satisfied
        /// </summary>
        public static void AddIf<T>(this List<T> source, bool condition, T item)
        {
            if (condition)
            {
                source.Add(item);
            }
        }

        public static bool HasMultipleItems<T>(this IList<T> source) => source.Count > 1;

        /// <summary>
        /// Checks if source has count same as <paramref name="count"/>.
        /// </summary>
        public static bool HasCountOf<T>(this IList<T> source, int count) => source.Count == count;

        /// <summary>
        /// Checks if source has count greather than <paramref name="count"/>.
        /// </summary>
        public static bool HasCountGreatherThan<T>(this IList<T> source, int count) => source.Count > count;
    }
}