namespace UserInterfaces
{
    using System;

    using Contracts;

    public class ConsoleUI : IBaloonsUserInterface
    {
        private const string COLUMN_INDECES = "    0 1 2 3 4 5 6 7 8 9 ";
        private const string SPACING = "   ";
        private const string EMPTY_CELL = "  ";
        private const string CELL_PRINTING_FORMAT = "{0,2}";
        private const string SIDE_BORDER = "|";
        private const char DASH = '-';
        private const int DEFAULT_COLOR_INDEX = 0;

        private readonly ConsoleColor[] consoleColors = new ConsoleColor[] { ConsoleColor.White, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.Yellow};

        public ConsoleUI()
        {
            this.SetConsoleColorToDefault();
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintField(byte[,] matrix)
        {
            //Console.Write("    ");
            //for (byte column = 0; column < matrix.GetLongLength(1); column++)
            //{
            //    Console.Write(column + " ");
            //}

            Console.WriteLine(COLUMN_INDECES);

            Console.WriteLine(SPACING + this.GetDashedLine(1 + matrix.GetLength(1) * 2));

            for (byte i = 0; i < matrix.GetLongLength(0); i++)
            {
                Console.Write(i + " " + SIDE_BORDER);
                for (byte j = 0; j < matrix.GetLongLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        Console.Write(EMPTY_CELL);
                        continue;
                    }

                    this.SetConsoleColor(matrix[i, j]);
                    Console.Write(CELL_PRINTING_FORMAT, matrix[i, j]);
                    this.SetConsoleColorToDefault();
                }

                Console.WriteLine(CELL_PRINTING_FORMAT, SIDE_BORDER);
            }


            Console.WriteLine(SPACING + this.GetDashedLine(1 + matrix.GetLength(1) * 2));

        }

        public void PrintHighscore(string highscore)
        {
            // TODO: implement
            throw new NotImplementedException("Implement me!");
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
    }
}