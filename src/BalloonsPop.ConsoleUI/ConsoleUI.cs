namespace BalloonsPop.ConsoleUI
{
    using System;
    using BalloonsPop.ConsoleUI.Contracts;
    using BalloonsPop.Common.Contracts;

    public class ConsoleUI : IConsoleUserInterface
    {
        private const string COLUMN_INDECES = "    0 1 2 3 4 5 6 7 8 9 ";
        private const string SPACING = "   ";
        private const string EMPTY_CELL = "  ";
        private const string CELL_PRINTING_FORMAT = "{0,2}";
        private const string SIDE_BORDER = "|";
        private const char DASH = '-';
        private const int DEFAULT_COLOR_INDEX = 0;

        private readonly ConsoleColor[] consoleColors = new ConsoleColor[] { ConsoleColor.White, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.Yellow };

        public ConsoleUI()
        {
            this.SetConsoleColorToDefault();
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintField(IBalloon[,] matrix)
        {
            this.PrintColumnIndeces();

            this.PrintDashedLine(1 + (matrix.GetLength(1) * 2));

            for (byte i = 0; i < matrix.GetLongLength(0); i++)
            {
                PrintRowBeggining(i);

                for (byte j = 0; j < matrix.GetLongLength(1); j++)
                {
                    PrintBalloon(matrix[i, j]);
                }

                this.SetConsoleColorToDefault();
                this.PrintRowEnd();
            }

            this.PrintDashedLine(1 + (matrix.GetLength(1) * 2));
        }

        // TODO: Improve the formatting using the predefined stuff
        public void PrintHighscore(IHighscoreTable highScore)
        {
            Console.WriteLine("---------TOP FIVE CHART-----------");

            for (int i = 0; i < highScore.Table.Count; i++)
            {
                var currentRow = highScore.Table[i];
                Console.WriteLine("{0}. {1} - {2} - {3}", i + 1, currentRow.Name, currentRow.Moves, currentRow.Time);
            }

            Console.WriteLine("----------------------------------");
        }

        public string ReadUserInput()
        {
            return Console.ReadLine();
        }

        private string GetDashedLine(int count)
        {
            var dashedLine = new string(DASH, count);

            return dashedLine;
        }

        private void SetConsoleColor(int key)
        {
            Console.ForegroundColor = this.consoleColors[key];
        }

        private void SetConsoleColorToDefault()
        {
            Console.ForegroundColor = this.consoleColors[DEFAULT_COLOR_INDEX];
        }

        private void PrintColumnIndeces()
        {
            Console.WriteLine(COLUMN_INDECES);
        }

        private void PrintDashedLine(int dashesCount)
        {
            Console.WriteLine(SPACING + this.GetDashedLine(dashesCount));
        }

        private void PrintRowBeggining(byte cellValue)
        {
            Console.Write(cellValue + " " + SIDE_BORDER);
        }

        private void PrintBalloon(IBalloon balloon)
        {
            if (balloon.isPopped)
            {
                Console.Write(EMPTY_CELL);
            }
            else
            {
                this.SetConsoleColor(balloon.Number);
                Console.Write(CELL_PRINTING_FORMAT, balloon.Number);
            }
        }

        private void PrintRowEnd()
        {
            Console.WriteLine(CELL_PRINTING_FORMAT, SIDE_BORDER);
        }
    }
}