namespace BalloonsPop.ConsoleUI
{
    using System;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.ConsoleUI.Contracts;

    public class ConsoleUI : IConsoleUserInterface
    {
        private const string ColumnIndices = "    0 1 2 3 4 5 6 7 8 9 ";
        private const string Spacing = "   ";
        private const string EmptyCell = "  ";
        private const string CellPrintingFormat = "{0,2}";
        private const string SideBorder = "|";
        private const char Dash = '-';
        private const int DefaultColorIndex = 0;

        private readonly ConsoleColor[] consoleColors = new ConsoleColor[] { ConsoleColor.White, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.Yellow };

        public ConsoleUI()
        {
            this.SetConsoleColorToDefault();
        }

        public void PrintPlayerMoves(string moves)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Moves count: " + moves);
            Console.ForegroundColor = ConsoleColor.White;
            
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintField(IBalloon[,] matrix)
        {
            Console.Clear();
            this.PrintColumnIndeces();

            this.PrintDashedLine(1 + (matrix.GetLength(1) * 2));

            for (byte i = 0; i < matrix.GetLongLength(0); i++)
            {
                this.PrintRowBeggining(i);

                for (byte j = 0; j < matrix.GetLongLength(1); j++)
                {
                    this.PrintBalloon(matrix[i, j]);
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
            var dashedLine = new string(Dash, count);

            return dashedLine;
        }

        private void SetConsoleColor(int key)
        {
            Console.ForegroundColor = this.consoleColors[key];
        }

        private void SetConsoleColorToDefault()
        {
            Console.ForegroundColor = this.consoleColors[DefaultColorIndex];
        }

        private void PrintColumnIndeces()
        {
            Console.WriteLine(ColumnIndices);
        }

        private void PrintDashedLine(int dashesCount)
        {
            Console.WriteLine(Spacing + this.GetDashedLine(dashesCount));
        }

        private void PrintRowBeggining(byte cellValue)
        {
            Console.Write(cellValue + " " + SideBorder);
        }

        private void PrintBalloon(IBalloon balloon)
        {
            if (balloon.IsPopped)
            {
                Console.Write(EmptyCell);
            }
            else
            {
                this.SetConsoleColor(balloon.Number);
                Console.Write(CellPrintingFormat, balloon.Number);
            }
        }

        private void PrintRowEnd()
        {
            Console.WriteLine(CellPrintingFormat, SideBorder);
        }
    }
}