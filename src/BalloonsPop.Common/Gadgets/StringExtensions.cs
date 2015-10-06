namespace BalloonsPop.Common.Gadgets
{
    using System;

    public static class StringExtensions
    {
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

        public static int ToInt32(this char ch)
        {
            int result = 0;
            bool successfulParse = int.TryParse(ch.ToString(), out result);

            if (!successfulParse)
            {
                throw new ArgumentException("String value was not in a valid parse from for an integer");
            }

            return result;
        }
    }
}
