namespace BalloonsPop.Common.Gadgets
{
    using System;

    /// <summary>
    /// Provides extensions methods for string and char types in order to facilitate working with the types.
    /// </summary>
    public static class StringExtensions
    {
        private const int DecimalCodeOfZero = 48;

        /// <summary>
        /// Converts the provided string to an INT32, throwing an exception in case of invalid string format.
        /// </summary>
        /// <param name="str">The string to be parsed to INT32.</param>
        /// <returns>The parsed integer value.</returns>
        public static int ToInt32(this string str)
        {
            int result = 0;
            bool successfulParse = int.TryParse(str, out result);

            if (!successfulParse)
            {
                throw new ArgumentException("String value was not in a valid parse from for an integer");
            }

            return result;
        }

        /// <summary>
        /// Converts the provided char digit to an INT32, throwing an exception in case of invalid string format.
        /// </summary>
        /// <param name="ch">The string to be parsed to INT32.</param>
        /// <returns>The parsed integer value.</returns>
        public static int ToInt32(this char ch)
        {
            bool canParse = char.IsDigit(ch);

            if (!canParse)
            {
                throw new ArgumentException("String value was not in a valid parse from for an integer");
            }

            return ch - DecimalCodeOfZero;
        }
    }
}
