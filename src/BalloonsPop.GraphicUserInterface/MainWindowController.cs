namespace BalloonsPop.GraphicUserInterface
{
    using System;
    using System.Linq;
    using System.Windows.Controls;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;
    using BalloonsPop.GraphicUserInterface.Contracts;
    using BalloonsPop.GraphicUserInterface.Gadgets;

    public class MainWindowController : IEventBasedUserInterface
    {
        private Image[,] balloons;

        public MainWindow Window { get; private set; }

        public IBalloonsWpfResourceProvider Resources { get; private set; }

        public MainWindowController(MainWindow window, IBalloonsWpfResourceProvider resources)
        {
            this.Window = window;

            this.Resources = resources;
            this.Window.CommandButtons.ForEach(button =>
            {
                button.Value.Click += (s, e) =>
                {
                    this.Window.Raise(s, new UserCommandArgs(button.Key));
                };
            });
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
                    var sourcePath = string.Format(this.Resources.ImagePathTemplate, this.Resources.Colors[colorNumber]);
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
                    this.balloons[i, j] = this.Resources.BalloonImage.Clone();

                    var commandToPassForButton = i + " " + j;

                    this.balloons[i, j]
                        .SetGridRow(i)
                        .SetGridCol(j)
                        .MouseDown += (s, e) =>
                    {
                        this.Window.Raise(s, new UserCommandArgs(commandToPassForButton));
                    };

                    this.balloons[i, j].AddAsChildTo(this.Window.BalloonGrid);

                    //this.Window.BalloonGrid.Children.Add(this.balloons[i, j]);
                }
            }
        }

        public event EventHandler RaiseCommand
        {
            add
            {
                this.Window.Raise += value;
            }
            remove
            {
                this.Window.Raise -= value;
            }
        }

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

            var tableAsMapList = table.ToStringLists();

            int rowIndex = 0;

            tableAsMapList.ForEach(record =>
            {
                int colIndex = 0;

                record.ForEach(infoField =>
                {
                    infoField
                        .WrapInTextBox(this.Resources.HighscoreGridCell.Clone())
                        .WrapInBorder(this.Resources.HighscoreGridBorder.Clone())
                        .SetGridRow(rowIndex)
                        .SetGridCol(colIndex++)
                        .AddAsChildTo(this.Window.Rankings);

                });

                rowIndex++;
            });
        }
    }
}
