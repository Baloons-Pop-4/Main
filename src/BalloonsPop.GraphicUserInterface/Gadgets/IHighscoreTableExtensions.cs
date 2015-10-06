namespace BalloonsPop.GraphicUserInterface.Gadgets
{
    using System.Collections.Generic;

    using BalloonsPop.Common.Contracts;

    public static class IHighscoreTableExtensions
    {
        private const string PlayerScoreKey = "score";
        private const string PlayerNameKey = "name";
        private const string PlayerTimeKey = "time";

        public static IList<IDictionary<string, string>> ToStringList(this IHighscoreTable table)
        {
            var result = new List<IDictionary<string, string>>();

            foreach (var record in table.Table)
            {
                var recordAsMap = new Dictionary<string, string>();

                recordAsMap.Add(PlayerScoreKey, record.Moves.ToString());
                recordAsMap.Add(PlayerNameKey, record.Name);
                recordAsMap.Add(PlayerTimeKey, record.Time.ToString());

                result.Add(recordAsMap);
            }

            return result;
        }
    }
}