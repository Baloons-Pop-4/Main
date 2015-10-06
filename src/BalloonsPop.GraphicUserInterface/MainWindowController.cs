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
    using BalloonsPop.Common.Gadgets;
    using BalloonsPop.GraphicUserInterface.Contracts;

    using BalloonsPop.GraphicUserInterface.Gadgets;

    public class MainWindowController : IEventBasedUserInterface
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

        private Image[,] balloons;

        public MainWindow Window { get; private set; }

        public MainWindowController(MainWindow window)
        {
            this.Window = window;

            var currentDir = Environment.CurrentDirectory;
            var imagesDir = currentDir.Substring(0, currentDir.IndexOf("bin"));
            this.sourcePathTemplate = imagesDir + "Images\\{0}.png";

            this.Window.StartButton.Click += (s, e) =>
                {
                    this.Window.StartButton.Content = "Restart";
                    this.Raise(s, new ClickEventArgs("restart"));
                };

            this.Window.UndoButton.Click += (s, e) =>
                {
                    this.Raise(s, new ClickEventArgs("undo"));
                };

            this.Window.ExitButton.Click += (s, e) =>
                {
                    this.Raise(s, new ClickEventArgs("exit"));
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

            this.Window.UserMoves = 3.ToString();
        }

        private void InitializeBalloonImageMatrix(int rowsCount, int colsCount)
        {
            this.balloons = new Image[rowsCount, colsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    this.balloons[i, j] = balloonImage.Clone();

                    var commandToPassForButton = i + " " + j;

                    this.balloons[i, j]
                        .SetGridRow(i)
                        .SetGridCol(j)
                        .MouseDown += (s, e) =>
                    {
                        this.Raise(s, new ClickEventArgs(commandToPassForButton));
                    };

                    this.balloons[i, j].AddAsChildTo(this.Window.BalloonGrid);

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
            this.Window.Rankings.Children.Clear();

            var tableAsMapList = table.ToStringList();

            int rowIndex = 0;

            tableAsMapList.ForEach(record =>
            {
                int colIndex = 0;

                record.ForEach(infoField =>
                {
                    infoField
                        .WrapInTextBox(highscoreCellContent.Clone())
                        .WrapInBorder(highscoreGridBorder.Clone())
                        .SetGridRow(rowIndex)
                        .SetGridCol(colIndex++)
                        .AddAsChildTo(this.Window.Rankings);

                    //colIndex++;
                });

                rowIndex++;
            });
        }
    }
}
