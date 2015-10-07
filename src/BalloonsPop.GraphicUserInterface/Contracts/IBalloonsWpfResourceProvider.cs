namespace BalloonsPop.GraphicUserInterface.Contracts
{
    using System.Windows.Controls;

    /// <summary>
    /// Interface for classes/structs that should implement resource providing for this application's view controller.
    /// </summary>
    public interface IBalloonsWpfResourceProvider
    {
        /// <summary>
        /// Provides readonly access to an array that holds the names of the colors of the balloons as string.
        /// </summary>
        string[] Colors { get; }

        /// <summary>
        /// Provides readonly access to the folder directory which contains the balloons images.
        /// </summary>
        string ImagePathTemplate { get; }

        /// <summary>
        /// Provides readonly access to a highscore cell component of the application's view;
        /// </summary>
        TextBlock HighscoreGridCell { get; }

        /// <summary>
        /// Provides readonly access to a highscore cell prototype border component of the application's view;
        /// </summary>
        Border HighscoreGridBorder { get; }

        /// <summary>
        /// Provides readonly access to a balloon image prototype of the application's view;
        /// </summary>
        Image BalloonImage { get; }
    }
}