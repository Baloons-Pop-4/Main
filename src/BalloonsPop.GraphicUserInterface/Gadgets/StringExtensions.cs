namespace BalloonsPop.GraphicUserInterface.Gadgets
{
    using System;
    using System.Windows.Controls;

    /// <summary>
    /// Provides additional functionality for the string struct.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Wraps a string in a TextBox element and returns the wrapper TextBox.
        /// </summary>
        /// <param name="text">The text to be wrapped inside the TextBox.</param>
        /// <param name="box">The wrapper TextBox.</param>
        /// <returns>Returns the same box it was passed as argument.</returns>
        public static TextBlock WrapInTextBox(this string text, TextBlock box)
        {
            if(text == null)
            {
                throw new NullReferenceException("Provided string was null");
            }

            if(box == null)
            {
                throw new NullReferenceException("Wrapper element was null");
            }

            box.Text = text;

            return box;
        }
    }
}
