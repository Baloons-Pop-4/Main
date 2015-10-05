using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop.GraphicUserInterface
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.GraphicUserInterface.Contracts;

    public class MainWindowController
    {
        private const int BalloonImgHeight = 40;
        private const int BalloonImgWidth = 30;

        private readonly string[] colors = new string[] { "white", "red", "blue", "green", "yellow" };

        private string imageFolderPath;

        public MainWindow Window { get; private set; }

        public MainWindowController(MainWindow window)
        {
            this.Window = window;
            this.imageFolderPath = GetBalloonImagesPath();
        }

        public Image GetBalloonImage()
        {
            var img = new Image()
            {
                Height = BalloonImgHeight,
                Width = BalloonImgWidth
            };

            return img;
        }

        private static string GetBalloonImagesPath()
        {
            var currentDir = Environment.CurrentDirectory;
            var result = currentDir.Substring(0, currentDir.IndexOf("bin"));

            return result;
        }

        private void SetSource(Image img, int balloonNumber)
        {
            var uri = this.GetBalloonImageUri(this.colors[balloonNumber]);
            img.Source = new BitmapImage(uri);
            // this.GetBalloonImageUri("white");
        }

        private Uri GetBalloonImageUri(string color)
        {
            var uri = new Uri(this.imageFolderPath + @"Images\" + color + ".png");
            return uri;
        }

        private void SetPositionInGrid(UIElement element, int row, int col)
        {
            Grid.SetRow(element, row);
            Grid.SetColumn(element, col);
        }

        private Border GetTextBlockWithBorder(string content)
        {
            return this.AddTextBlockToBorder(this.GetBorder(), content);
        }

        private Border GetBorder()
        {
            var result = new Border()
            {
                BorderThickness = new Thickness(1, 2, 1, 2),
                BorderBrush = Brushes.Coral
            };

            return result;
        }

        private Border AddTextBlockToBorder(Border border, string content)
        {
            var textBlock = new TextBlock();
            textBlock.Text = content;
            this.StyleTextBlock(textBlock);
            border.Child = textBlock;

            return border;
        }

        private void StyleTextBlock(TextBlock block)
        {
            block.TextAlignment = TextAlignment.Center;
            block.VerticalAlignment = System.Windows.VerticalAlignment.Center;
        }
    }
}
