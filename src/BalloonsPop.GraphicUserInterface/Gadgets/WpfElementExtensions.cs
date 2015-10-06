namespace BalloonsPop.GraphicUserInterface.Gadgets
{

    using System;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Xml;

    public static class WpfElementExtensions
    {
        public static Panel WrapIn(this UIElement wrapee, Panel wrapper)
        {
            wrapper.Children.Add(wrapee);

            return wrapper;
        }

        public static Panel WrapIn(this UIElementCollection wrapees, Panel wrapper)
        {
            foreach (var item in wrapees)
            {
                wrapper.Children.Add(item as UIElement);
            }

            return wrapper;
        }

        public static Border WrapInBorder(this UIElement wrapee, Border border)
        {
            if(wrapee == null)
            {
                throw new NullReferenceException("UIElement was null");
            }

            border.Child = wrapee;

            return border;
        }

        public static UIElement SetGridRow(this UIElement gridElement, int row)
        {
            Grid.SetRow(gridElement, row);

            return gridElement;
        }

        public static UIElement SetGridCol(this UIElement gridElement, int column)
        {
            Grid.SetColumn(gridElement, column);

            return gridElement;
        }

        public static Image SetSource(this Image image, string path)
        {
            image.Source = new BitmapImage(new Uri(path));

            return image;
        }

        public static UIElement AddAsChildTo(this UIElement element, Panel container)
        {
            if(element == null)
            {
                throw new NullReferenceException("Provided element was null");
            }

            container.Children.Add(element);

            return element;
        }

        public static T Clone<T>(this T uiElement)
            where T : UIElement
        {
            var elementAsString = XamlWriter.Save(uiElement);

            var reader = new StringReader(elementAsString);
            var xmlReader = XmlReader.Create(reader);

            return (T)(XamlReader.Load(xmlReader));
        }
    }
}
