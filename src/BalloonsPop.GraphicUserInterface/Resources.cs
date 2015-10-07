namespace BalloonsPop.GraphicUserInterface
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using BalloonsPop.GraphicUserInterface.Contracts;

    /// <summary>
    /// Provides various resources for the constructrion and manipulation of the MainWindow class.
    /// </summary>
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

        /// <summary>
        /// Returns an array of strings that represent the five different balloon colors(white for popped, red, blue, green, yellow).
        /// </summary>
        public string[] Colors
        {
            get
            {
                return colors;
            }
        }

        /// <summary>
        /// Returns the absolute path to the folder with balloon images.
        /// </summary>
        public string ImagePathTemplate
        {
            get
            {
                return sourcePathTemplate;
            }
        }

        /// <summary>
        /// Returns a TextBlock element styled to be a cell in the highscore grid.
        /// </summary>
        public TextBlock HighscoreGridCell
        {
            get
            {
                return highscoreCellContent;
            }
        }

        /// <summary>
        /// Returns a Border element styled to be a border of a cell in the highscore grid.
        /// </summary>
        public Border HighscoreGridBorder
        {
            get
            {
                return highscoreGridBorder;
            }
        }

        /// <summary>
        /// Returns an image resized and styled to be a balloon visualization.
        /// </summary>
        public Image BalloonImage
        {
            get
            {
                return balloonImage;
            }
        }
    }
}