using System;
using System.Text;

using Contracts;

public class ConsoleUI : IBaloonsUserInterface
{
    private const string COLUMNS_INDECES = "    0 1 2 3 4 5 6 7 8 9 ";
    private const string EMPTY_SPOT = "  ";

    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void PrintField(byte[,] matrix)
    {
        var result = new StringBuilder();

        result.AppendLine(COLUMNS_INDECES);
        result.AppendLine(this.GetFieldFrame(matrix.GetLength(1)));

        for (byte i = 0; i < matrix.GetLongLength(0); i++)
        {
            result.Append(i + " | ");
            for (byte j = 0; j < matrix.GetLongLength(1); j++)
            {
                if (matrix[i, j] == 0)
                {
                    result.Append(EMPTY_SPOT);
                    
                }
                else
                {
                    result.Append(matrix[i, j] + " ");
                }

                
            }

            result.AppendLine("| ");
        }

        result.Append(this.GetFieldFrame(matrix.GetLength(1)));

        Console.WriteLine(result);
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

    private string GetFieldFrame(int repeat)
    {
        var fieldFrame = "   " + new string('-', repeat * 2 + 1);
        return fieldFrame;
    }
}