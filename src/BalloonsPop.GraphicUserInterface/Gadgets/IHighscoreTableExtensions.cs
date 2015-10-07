namespace BalloonsPop.GraphicUserInterface.Gadgets
{
    using System;
    using System.Collections.Generic;

    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Provides additional functionality for the IHighscoreTable type.
    /// </summary>
    public static class IHighscoreTableExtensions
    {
        /// <summary>
        /// Converts the calling IHighscoreTable to a List<List<string>>.
        /// </summary>
        /// <param name="table">The table that will be converted to string lists.</param>
        /// <returns>Returns a list represantation of the table. Each row containts the following info as string: index, player name and score</returns>
        public static IList<IList<string>> ToStringLists(this IHighscoreTable table)
        {
            if(table == null)
            {
                throw new NullReferenceException("Provided table was null");
            }

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