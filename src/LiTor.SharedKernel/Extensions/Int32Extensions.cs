namespace System
{
    public static class Int32Extensions
    {
        /// <summary>
        /// Returns number of digits in <paramref name="value"/>
        /// If performance matter, use faster solutions/
        /// </summary>
        public static int GetNumberOfDigits(this int value) => value.ToString().Length;
    }
}