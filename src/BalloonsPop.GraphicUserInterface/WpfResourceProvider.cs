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

    public class WpfResourceProvider
    {
        private const int BalloonImgHeight = 40;
        private const int BalloonImgWidth = 30;

        public string GetBalloonImagesPath()
        {
            var currentDir = Environment.CurrentDirectory;
            var result = currentDir.Substring(0, currentDir.IndexOf("bin"));

            return result;
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

        public Border GetBorder()
        {
            var result = new Border()
            {
                BorderThickness = new Thickness(1, 2, 1, 2),
                BorderBrush = Brushes.Coral
            };

            return result;
        }

        public TextBlock GetTextBlock(string content)
        {
            var textBlock = new TextBlock()
            {
                Text = content,
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            return textBlock;
        }
    }
}
