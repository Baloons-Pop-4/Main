namespace BalloonsPop.GraphicUserInterface.Gadgets
{
    using System.Collections.Generic;

    using BalloonsPop.Common.Contracts;

    public static class IHighscoreTableExtensions
    {
        public static IList<IList<string>> ToStringLists(this IHighscoreTable table)
        {
            var result = new List<IList<string>>();

            var index = 1;

            foreach (var record in table.Table)
            {
                var currentRecord = new List<string>();

                currentRecord.Add((index++).ToString());
                currentRecord.Add(record.Name);
                currentRecord.Add(record.Moves.ToString());
                
                result.Add(currentRecord);
            }

            return result;
        }
    }
}