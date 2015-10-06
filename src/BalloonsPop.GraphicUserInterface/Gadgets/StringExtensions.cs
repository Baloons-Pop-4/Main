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
                throw new NullReferenceException("Cannot wrap null string!");
            }

            box.Text = text;
            return box;
        }
    }
}
