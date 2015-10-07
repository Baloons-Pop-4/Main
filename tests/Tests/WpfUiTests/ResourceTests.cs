using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using BalloonsPop.GraphicUserInterface;
using BalloonsPop.GraphicUserInterface.Contracts;
using BalloonsPop.GraphicUserInterface.Gadgets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.WpfUiTests
{
    [TestClass]
    public class ResourceTests
    {
        IBalloonsWpfResourceProvider resourceProvider;

        [TestInitialize]
        public void TestInit()
        {
            this.resourceProvider = new Resources();
        }

        [TestMethod]
        public void TestIfResourceReturnsCorrectBorder()
        {
            var expected = XamlWriter.Save(new Border()
            {
                BorderThickness = new Thickness(1, 2, 1, 2),
                BorderBrush = Brushes.Coral
            });

            var actual = XamlWriter.Save(resourceProvider.HighscoreGridBorder);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIfResourceReturnsCorrectTextBlock()
        {
            var expected = XamlWriter.Save(new TextBlock()
            {
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            });

            var actual = XamlWriter.Save(resourceProvider.HighscoreGridCell);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIfColorsPropertyReturnsTheCorrectArray()
        {
            var expected = "white red blue green yellow";
            var actual = string.Join(" ", this.resourceProvider.Colors);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIfBalloonImageHasCorrectHeightAndWidth()
        {
            Assert.AreEqual(40, this.resourceProvider.BalloonImage.Height);
            Assert.AreEqual(30, this.resourceProvider.BalloonImage.Width);
        }
    }
}
