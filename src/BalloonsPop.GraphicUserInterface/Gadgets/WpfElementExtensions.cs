namespace BalloonsPop.GraphicUserInterface.Gadgets
{

    using System;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Windows.Media.Imaging;
    using System.Xml;

    public static class WpfElementExtensions
    {
        public static Border WrapInBorder(this UIElement wrapee, Border border)
        {
            if (wrapee == null)
            {
                throw new NullReferenceException("Caller UIElement was null");
            }

            if (border == null)
            {
                throw new NullReferenceException("Provided border was null");
            }

            border.Child = wrapee;

            return border;
        }

        public static UIElement SetGridRow(this UIElement gridElement, int row)
        {
            if (gridElement == null)
            {
                throw new NullReferenceException("Caller element was null");
            }

            if (row < 0)
            {
                throw new ArgumentOutOfRangeException("Provided row had negative value");
            }

            Grid.SetRow(gridElement, row);

            return gridElement;
        }

        public static UIElement SetGridCol(this UIElement gridElement, int column)
        {
            if (gridElement == null)
            {
                throw new NullReferenceException("Caller element was null");
            }

            if (column < 0)
            {
                throw new ArgumentOutOfRangeException("Provided column had negative value");
            }

            Grid.SetColumn(gridElement, column);

            return gridElement;
        }

        public static Image SetSource(this Image image, string path)
        {
            if(image == null)
            {
                throw new NullReferenceException("Caller image was null");
            }

            if(string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Provided path was empty");
            }

            image.Source = new BitmapImage(new Uri(path));

            return image;
        }

        public static UIElement AddAsChildTo(this UIElement element, Panel container)
        {
            if (element == null)
            {
                throw new NullReferenceException("Caller element was null");
            }

            if(container == null)
            {
                throw new NullReferenceException("Provided container was null");
            }

            container.Children.Add(element);

            return element;
        }

        public static T Clone<T>(this T uiElement)
            where T : UIElement
        {
            if(uiElement == null)
            {
                throw new NullReferenceException("Caller element was null");
            }

            var elementAsString = XamlWriter.Save(uiElement);

            var reader = new StringReader(elementAsString);
            var xmlReader = XmlReader.Create(reader);

            return (T)(XamlReader.Load(xmlReader));
        }


    }
}
