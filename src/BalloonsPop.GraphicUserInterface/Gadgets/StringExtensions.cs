namespace BalloonsPop.GraphicUserInterface.Gadgets
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public static class StringExtensions
    {
        public static TextBlock WrapInTextBox(this string text, bool centered = false)
        {
            if(text == null)
            {
                throw new NullReferenceException("Cannot wrap null string!");
            }

            var box = new TextBlock()
            {
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            return text.WrapInTextBox(box);
        }

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
