namespace BalloonsPop.GraphicUserInterface.Gadgets
{
    using System;
    using System.Windows.Controls;

    public static class StringExtensions
    {
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
