namespace BalloonsPop.Highscore.HighscoreHandlingStrategies
{
    using System.Collections.Generic;
    using System.IO;

    using BalloonsPop.Common.Contracts;

    using Newtonsoft.Json;

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
            string json = File.ReadAllText(FilePath);
            var copy = JsonConvert.DeserializeObject<List<IPlayerScore>>(json);
            return new HighscoreTable(copy);
        }
    }
}
