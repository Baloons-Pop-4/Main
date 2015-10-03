namespace BalloonsPop.Highscore.HighscoreHandlingStrategies
{
    using System.Collections.Generic;
    using System.IO;

    using BalloonsPop.Common.Contracts;

    using Newtonsoft.Json;
    using System;

    public class JsonHandlingStrategy : IHighscoreHandlingStrategy
    {
        private const string FilePath = "highscore.json";

        public void Save(IHighscoreTable table)
        {
            string json = JsonConvert.SerializeObject(table.Table.ToArray(), Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }

        public IHighscoreTable Load()
        {
            try
            {
                string json = File.ReadAllText(FilePath);
                var playerScores = JsonConvert.DeserializeObject<List<PlayerScore>>(json);
                return new HighscoreTable(playerScores);
            }
            catch (Exception e)
            {
                // Call Logger.Warn() here -> "No highscore.json, falling back to empty highscore table."
                return new HighscoreTable();
            }
        }
    }
}
