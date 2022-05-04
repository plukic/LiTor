namespace System
{
    /// <summary>
    /// Extension methods for <see cref="DateTime"/>
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Returns start of the <paramref name="dateTime"/> day
        /// </summary>
        public static DateTime StartOfTheDay(this DateTime dateTime)
            => dateTime.Date;

        /// <summary>
        /// Returns start of the <paramref name="dateTime"/> day
        /// </summary>
        public static DateTime? StartOfTheDay(this DateTime? dateTime)
            => dateTime.HasValue ? dateTime.Value.Date : (DateTime?)null;

        /// <summary>
        /// Returns end of the <paramref name="dateTime"/> day
        /// </summary>
        public static DateTime EndOfTheDay(this DateTime dateTime)
            => dateTime.Date.AddDays(1);

        /// <summary>
        /// Returns end of the <paramref name="dateTime"/> day
        /// </summary>
        public static DateTime? EndOfTheDay(this DateTime? dateTime)
            => dateTime.HasValue ? dateTime.Value.Date.AddDays(1) : (DateTime?)null;
    }
}