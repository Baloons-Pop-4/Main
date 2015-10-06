namespace BalloonsPop.GraphicUserInterface.Gadgets
{

    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public static class WpfElementExtensions
    {
        public static UIElement WrapIn(this UIElement wrapee, Panel wrapper)
        {
            wrapper.Children.Add(wrapee);

            return wrapper;
        }

        public static UIElement WrapIn(this UIElementCollection wrapees, Panel wrapper)
        {
            foreach (var item in wrapees)
            {
                wrapper.Children.Add(item as UIElement);
            }

            return wrapper;
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
    }
}
