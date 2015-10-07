namespace BalloonsPop.GraphicUserInterface
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using BalloonsPop.GraphicUserInterface.Contracts;

    public class Resources : IBalloonsWpfResourceProvider
    {
        private const int BalloonImgHeight = 40;
        private const int BalloonImgWidth = 30;

        private readonly string[] colors = new string[] { "white", "red", "blue", "green", "yellow" };

        private readonly string sourcePathTemplate;

        private static readonly Border highscoreGridBorder = new Border()
            {
                BorderThickness = new Thickness(1, 2, 1, 2),
                BorderBrush = Brushes.Coral
            };

        private static readonly TextBlock highscoreCellContent = new TextBlock()
            {
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

        private static readonly Image balloonImage = new Image()
            {
                Height = BalloonImgHeight,
                Width = BalloonImgWidth
            };

        public Resources()
        {
            var currentDir = Environment.CurrentDirectory;
            var imagesDir = currentDir.Substring(0, currentDir.IndexOf("bin"));
            this.sourcePathTemplate = imagesDir + "Images\\{0}.png";
        }

        public string[] Colors
        {
            get
            {
                return colors;
            }
        }

        public string ImagePathTemplate
        {
            get
            {
                return sourcePathTemplate;
            }
        }

        public TextBlock HighscoreGridCell
        {
            get
            {
                return highscoreCellContent;
            }
        }

        public Border HighscoreGridBorder
        {
            get
            {
                return highscoreGridBorder;
            }
        }

        public Image BalloonImage
        {
            get
            {
                return balloonImage;
            }
        }
    }
}