using System;

using Contracts;

public class ConsoleUI : IBaloonsUserInterface
{
    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void PrintField(byte[,] matrix)
    {
        Console.Write("    ");
        for (byte column = 0; column < matrix.GetLongLength(1); column++)
        {
            Console.Write(column + " ");
        }

        Console.Write(Environment.NewLine + "   " + new string('-', matrix.GetLength(1) * 2 + 1) + Environment.NewLine);

        for (byte i = 0; i < matrix.GetLongLength(0); i++)
        {
            Console.Write(i + " | ");
            for (byte j = 0; j < matrix.GetLongLength(1); j++)
            {
                if (matrix[i, j] == 0)
                {
                    Console.Write("  ");
                    continue;
                }

                Console.Write(matrix[i, j] + " ");
            }

            Console.WriteLine("| ");
        }

        Console.Write("   " + new string('-', matrix.GetLength(1) * 2 + 1) + Environment.NewLine);

    }

    public void PrintHighscore(string highscore)
    {
        // TODO: implement
        throw new NotImplementedException("Implement me!");
    }
}