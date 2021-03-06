﻿namespace BalloonsPop.ConsoleUserInterface
{
    using System;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.ConsoleUserInterface.Gadgets;

    using GnomUi.Contracts;
    using GnomUi.TreeComponents;

    /// <summary>
    /// Server as manipulator for the application's view.
    /// </summary>
    public class GnomController : IPrinter
    {
        private const string PoppedBalloonContent = "X";
        private const string WholeBalloonContent = "Q";
        private const string FieldId = "field";
        private const string RestartButtonId = "restart";
        private const string MessageBoxId = "message-box";
        private const string ScoreBoxId = "score";

        private const int PlayerScoreMargin = 2;
        private const int HighscoreTableHeightIncrement = 4;
        private const int BalloonPaddingLeftMultiplier = 4;
        private const int BalloonPaddingTopMultiplier = 2;

        private static readonly ConsoleColor[] Colors = 
        { 
            ConsoleColor.Black, 
            ConsoleColor.Red, 
            ConsoleColor.Green,
            ConsoleColor.Blue, 
            ConsoleColor.Yellow 
        };

        private TextElement[,] cachedField;

        private INodeElement field;

        /// <summary>
        /// Assign a gnom view to the current instance.
        /// </summary>
        /// <param name="view"></param>
        public GnomController(IGnomTree view)
        {
            this.View = view;
            this.field = this.View[FieldId];

            // TODO: extract in resource provider
            var text2 = new TextElement("Current moves: 0");
            text2.Style.PaddingTop = 3;
            this.View[MessageBoxId].AddChild(text2);
        }

        /// <summary>
        /// Provides access to the view that the current instance is responsible for managing.
        /// </summary>
        public IGnomTree View { get; private set; }

        /// <summary>
        /// Prints a message on view.
        /// </summary>
        /// <param name="message"></param>
        public void PrintMessage(string message)
        {
            (this.View[MessageBoxId].Children[0] as ITextElement).Content = message;
        }

        /// <summary>
        /// Display the provided string in the section for user moves.
        /// </summary>
        /// <param name="moves"></param>
        public void PrintPlayerMoves(string moves)
        {
            (this.View[MessageBoxId].Children[1] as ITextElement).Content = "Current moves: " + moves;
        }

        /// <summary>
        /// Updates the view with information from the provided balloon matrix.
        /// </summary>
        /// <param name="matrix"></param>
        public void PrintField(IBalloon[,] matrix)
        {
            if (this.cachedField == null)
            {
                this.InitializeField(matrix);

                return;
            }

            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            int popped = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    var childToUpdate = this.cachedField[i, j];
                    childToUpdate.Style.Color = Colors[matrix[i, j].IsPopped ? 0 : matrix[i, j].Number];

                    if (matrix[i, j].IsPopped)
                    {
                        childToUpdate.Content = PoppedBalloonContent;
                        popped++;
                    }
                }
            }

            if (popped >= (rows * columns) - 1)
            {
                foreach (var element in this.cachedField)
                {
                    element.Content = WholeBalloonContent;
                }
            }
        }

        /// <summary>
        /// Prints the highscore in the rankings section of the view.
        /// </summary>
        /// <param name="table"></param>
        public void PrintHighscore(IHighscoreTable table)
        {
            this.View[ScoreBoxId].Style.Color = ConsoleColor.White;

            var rankings = table.Table;
            for (int i = 0; i < rankings.Count; i++)
            {
                // TODO: extract in resource provider
                var scoreToAdd = new TextElement(rankings[i].Stringify(i + 1));
                scoreToAdd.Style.PaddingTop = (i * PlayerScoreMargin) + 1;

                this.View.AddChildToParent(this.View[ScoreBoxId], scoreToAdd);
                this.View[ScoreBoxId].Style.Height = table.Table.Count * HighscoreTableHeightIncrement;
            }
        }

        private void InitializeField(IBalloon[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            this.cachedField = new TextElement[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    // TODO: extract in resource provider
                    var childToAdd = new TextElement(WholeBalloonContent);

                    childToAdd.Style = new Style()
                    {
                        PaddingLeft = j * BalloonPaddingLeftMultiplier,
                        PaddingTop = i * BalloonPaddingTopMultiplier,
                        Color = Colors[matrix[i, j].IsPopped ? 0 : matrix[i, j].Number]
                    };

                    childToAdd.Id = i + " " + j;

                    // cache
                    this.cachedField[i, j] = childToAdd;

                    this.View.AddChildToParent(this.field, childToAdd);

                    // link to neighbors
                    if (i > 0)
                    {
                        childToAdd.LinkTo(ConsoleKey.UpArrow, this.cachedField[i - 1, j]);
                    }

                    if (j > 0)
                    {
                        childToAdd.LinkTo(ConsoleKey.LeftArrow, this.cachedField[i, j - 1]);
                    }
                }
            }

            for (int i = columns - 1; i >= 0; i--)
            {
                this.cachedField[rows - 1, i].LinkTo(ConsoleKey.DownArrow, this.View[RestartButtonId]);
            }
        }
    }
}