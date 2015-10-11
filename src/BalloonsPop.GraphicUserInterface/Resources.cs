namespace BalloonsPop.GraphicUserInterface
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using BalloonsPop.GraphicUserInterface.Contracts;

    /// <summary>
    /// Provides various resources for the construction and manipulation of the MainWindow class.
    /// </summary>
    public class Resources : IBalloonsWpfResourceProvider
    {
        private const int BalloonImgHeight = 40;
        private const int BalloonImgWidth = 30;
        private const string ExectutionFolderName = "bin";

        private static readonly string[] ColorNames = new string[] { "white", "red", "blue", "green", "yellow" };

        private static readonly Border HighscoreGridBorderElement = new Border()
            {
                BorderThickness = new Thickness(1, 2, 1, 2),
                BorderBrush = Brushes.Coral
            };

        private static readonly TextBlock HighscoreCellContentElement = new TextBlock()
            {
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

        private static readonly Image BalloonImageElement = new Image()
            {
                Height = BalloonImgHeight,
                Width = BalloonImgWidth
            };

        private static string sourcePathTemplate;

        /// <summary>
        /// Initializes a new instance of the <see cref="Resources" /> class.
        /// </summary>
        public Resources()
        {
            int indexOfExecutionFolderName = Environment.CurrentDirectory.IndexOf(ExectutionFolderName);
            var imagesDir = Environment.CurrentDirectory.Substring(0, indexOfExecutionFolderName);
            sourcePathTemplate = imagesDir + "Images\\{0}.png";
        }

        /// <summary>
        /// Gets an array of strings that represent the five different balloon colors(white for popped, red, blue, green, yellow).
        /// </summary>
        public string[] Colors
        {
            get
            {
                return ColorNames;
            }
        }

        /// <summary>
        /// Gets the absolute path to the folder with balloon images.
        /// </summary>
        public string ImagePathTemplate
        {
            get
            {
                return sourcePathTemplate;
            }
        }

        /// <summary>
        /// Gets a TextBlock element styled to be a cell in the highscore grid.
        /// </summary>
        public TextBlock HighscoreGridCell
        {
            get
            {
                return HighscoreCellContentElement;
            }
        }

        /// <summary>
        /// Gets a Border element styled to be a border of a cell in the highscore grid.
        /// </summary>
        public Border HighscoreGridBorder
        {
            get
            {
                return HighscoreGridBorderElement;
            }
        }

        /// <summary>
        /// Gets an image resized and styled to be a balloon visualization.
        /// </summary>
        public Image BalloonImage
        {
            get
            {
                return BalloonImageElement;
            }
        }
    }
}