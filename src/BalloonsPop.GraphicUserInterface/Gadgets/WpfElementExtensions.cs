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

    /// <summary>
    /// Provides additional functionality for wpf ui elements.
    /// </summary>
    public static class WpfElementExtensions
    {
        /// <summary>
        /// Wraps an UIElement in a provided Border and returns the wrapper Border.
        /// </summary>
        /// <param name="wrapee">The UIElement to be wrapped.</param>
        /// <param name="border">The Border wrapper.</param>
        /// <returns>The same Border element it was passed.</returns>
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

        /// <summary>
        /// Set the GridRow of the caller UIElement and returns the element.
        /// </summary>
        /// <param name="gridElement">The element whose GridRow will be set.</param>
        /// <param name="row">The value to which the element's GridRow will be set.</param>
        /// <returns>The element whose GridRow was set with this method's invocation.</returns>
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

        /// <summary>
        /// Set the GridCol of the caller UIElement and returns the element.
        /// </summary>
        /// <param name="gridElement">The element whose GridCol will be set.</param>
        /// <param name="column">The value to which the element's GridCol will be set.</param>
        /// <returns>The element whose GridCol was set with this method's invocation.</returns>
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

        /// <summary>
        /// Sets the source path of an image to a bitmap image with a uri that is created using the provided path.
        /// </summary>
        /// <param name="image">The image whose source will be set.</param>
        /// <param name="path">The path to the uri.</param>
        /// <returns>The same Image that invoked the method.</returns>
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

        /// <summary>
        /// Adds an UIElement to the provided Panel's children and returns the UIElement.
        /// </summary>
        /// <param name="element">The element to be added as child to the Panel.</param>
        /// <param name="container">The UIElements new parent.</param>
        /// <returns>The same UIElement that invoked the method.</returns>
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

        /// <summary>
        /// Clones an UIElement using serialization into string and then loading.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uiElement"></param>
        /// <returns></returns>
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