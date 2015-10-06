namespace BalloonsPop.GraphicUserInterface.Contracts
{
    using System.Windows.Controls;

    public interface IBalloonsWpfResourceProvider
    {
        string[] Colors { get; }

        string ImagePathTemplate { get; }

        int BalloonImageHeight { get; }

        int BalloonImageWidth { get; }

        TextBlock HighscoreGridCell { get; }

        Border HighscoreGridBorder { get; }

        Image BalloonImage { get; }
    }
}