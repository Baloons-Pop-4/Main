using System;
using System.Collections.Generic;

public struct PlayerScore : IComparable<PlayerScore>
{
    public int Value;
    public string Name;
    public PlayerScore(int value, string name)
    {

        Value = value;
        Name = name;
    }

    public int CompareTo(PlayerScore other)
    {
        return Value.CompareTo(other.Value);
    }
}

public class HighScoreUtility
{
    public static void sortAndPrintChartFive(string[,] tableToSort)
    {

        List<PlayerScore> klasirane = new List<PlayerScore>();

        for (int i = 0; i < 5; ++i)
        {
            if (tableToSort[i, 0] == null)
            {
                break;
            }

            klasirane.Add(new PlayerScore(int.Parse(tableToSort[i, 0]), tableToSort[i, 1]));

        }

        klasirane.Sort();
        Console.WriteLine("---------TOP FIVE CHART-----------");
        for (int i = 0; i < klasirane.Count; ++i)
        {
            PlayerScore slot = klasirane[i];
            Console.WriteLine("{2}.   {0} with {1} moves.", slot.Name, slot.Value, i + 1);
        }
        Console.WriteLine("----------------------------------");


    }

    public static bool signIfSkilled(string[,] Chart, int points)
    {
        bool Skilled = false;
        int worstMoves = 0;
        int worstMovesChartPosition = 0;
        for (int i = 0; i < 5; i++)
        {
            if (Chart[i, 0] == null)
            {
                Console.WriteLine("Type in your name.");
                string tempUserName = Console.ReadLine();
                Chart[i, 0] = points.ToString();
                Chart[i, 1] = tempUserName;
                Skilled = true;
                break;
            }
        }
        if (Skilled == false)
        {
            for (int i = 0; i < 5; i++)
            {
                if (int.Parse(Chart[i, 0]) > worstMoves)
                {
                    worstMovesChartPosition = i;
                    worstMoves = int.Parse(Chart[i, 0]);
                }
            }
        }
        if (points < worstMoves && Skilled == false)
        {
            Console.WriteLine("Type in your name.");
            string tempUserName = Console.ReadLine();
            Chart[worstMovesChartPosition, 0] = points.ToString();
            Chart[worstMovesChartPosition, 1] = tempUserName;
            Skilled = true;
        }
        return Skilled;
    }
}