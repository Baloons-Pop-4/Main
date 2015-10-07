namespace BalloonsPop.GraphicUserInterface
{
    using System;
    using System.Linq;
    using System.Windows.Controls;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;
    using BalloonsPop.GraphicUserInterface.Contracts;
    using BalloonsPop.GraphicUserInterface.Gadgets;

    /// <summary>
    /// Implements the IEventBasedUserInterface and updates the view on command of the engine.
    /// </summary>
    public class MainWindowController : IEventBasedUserInterface
    {
        private Image[,] balloons;

        /// <summary>
        /// Returns the view which the current instance of the controller is responsible for managing.
        /// </summary>
        public MainWindow Window { get; private set; }

        /// <summary>
        /// Returns the resource provider which the current instance of the controller is using.
        /// </summary>
        public IBalloonsWpfResourceProvider Resources { get; private set; }

        /// <summary>
        /// Public constructor that initializes a newly created controller instance with view and resource provider.
        /// </summary>
        /// <param name="window">The view which the newly created instance is responsible for managing.</param>
        /// <param name="resources">The resource provider which the newly created instance will query for resources.</param>
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

        /// <summary>
        /// Introduces updates on the view bases on the provided IBalloon two-dimensional array.
        /// </summary>
        /// <param name="matrix">The array which is used as a blueprint for introducing changes to the view.</param>
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
                }
            }
        }

        /// <summary>
        /// Used to add and remove methods from the view's event handler.
        /// </summary>
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

        /// <summary>
        /// Displays the view and returns without waiting for the view to close.
        /// </summary>
        public void Show()
        {
            this.Window.Show();
        }

        /// <summary>
        /// Updates the view's message section.
        /// </summary>
        /// <param name="message">The message to be shown to the user.</param>
        public void PrintMessage(string message)
        {
            this.Window.Message = message;
        }

        /// <summary>
        /// Updates the ranking of the view based on the provided IHighscoreTable instance.
        /// </summary>
        /// <param name="table">The highscore table on which the introduced changes are based.</param>
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
