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

    using BalloonsPop.GraphicUserInterface.Gadgets;

    public class MainWindowController : IEventBasedUserInterface
    {
        private readonly string[] colors = new string[] { "white", "red", "blue", "green", "yellow" };

        private readonly string sourcePathTemplate;

        private Image[,] balloons;

        public MainWindow Window { get; private set; }

        public WpfResourceProvider ResourceProvider { get; private set; }

        public MainWindowController(MainWindow window, WpfResourceProvider resourceProvider)
        {
            this.Window = window;
            this.ResourceProvider = resourceProvider;
            this.sourcePathTemplate = this.ResourceProvider.GetBalloonImagesPath() + "Images\\{0}.png";
            this.Window.StartButton.Click += (s, e) =>
                {
                    this.Window.StartButton.Content = "Restart";
                    this.Raise(s, new ClickEventArgs("restart"));
                };
        }

        public void PrintField(IBalloon[,] matrix)
        {
            var rowsCount = matrix.GetLength(0);
            var colsCount = matrix.GetLength(1);

            if (this.balloons == null)
            {
                this.InitializeBalloonImageMatrix(rowsCount, colsCount);
            }

            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    var colorNumber = matrix[row, col].IsPopped ? 0 : matrix[row, col].Number;
                    var sourcePath = string.Format(this.sourcePathTemplate, colors[colorNumber]);
                    this.balloons[row, col].SetSource(sourcePath);
                }
            }
        }

        private void InitializeBalloonImageMatrix(int rowsCount, int colsCount)
        {
            this.balloons = new Image[rowsCount, colsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    this.balloons[i, j] = this.ResourceProvider.GetBalloonImage();

                    var commandToPassForButton = i + " " + j;

                    this.balloons[i, j]
                        .SetGridRow(i)
                        .SetGridCol(j)
                        .MouseDown += (s, e) =>
                    {
                        this.Raise(s, new ClickEventArgs(commandToPassForButton));
                    };

                    this.balloons[i, j].WrapIn(this.Window.BalloonGrid);

                    //this.Window.BalloonGrid.Children.Add(this.balloons[i, j]);
                }
            }
        }

        public event EventHandler Raise;

        public void Show()
        {
            this.Window.Show();
        }

        public void PrintMessage(string message)
        {
            this.Window.Message = message;
        }

        public void PrintHighscore(IHighscoreTable table)
        {
            var row = 0;
            this.Window.Rankings.Children.Clear();
            foreach (var score in table.Table)
            {
                var border1 = this.ResourceProvider.GetBorder();
                var border2 = this.ResourceProvider.GetBorder();
                var border3 = this.ResourceProvider.GetBorder();

                var playerName = this.ResourceProvider.GetTextBlock(score.Name);
                var playerScore = this.ResourceProvider.GetTextBlock(score.Moves.ToString());
                var playerRank = this.ResourceProvider.GetTextBlock((row + 1).ToString());

                border1.Child = playerName;
                border2.Child = playerScore;
                border3.Child = playerRank;

                border3.SetGridRow(row).SetGridCol(0);
                border1.SetGridRow(row).SetGridCol(1);
                border2.SetGridRow(row).SetGridCol(2);

                this.Window.Rankings.Children.Add(border3);
                this.Window.Rankings.Children.Add(border1);
                this.Window.Rankings.Children.Add(border2);
                row++;
            }
        }
    }
}
