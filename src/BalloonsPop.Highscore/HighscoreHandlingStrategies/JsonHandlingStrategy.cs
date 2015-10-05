namespace BalloonsPop.Highscore.HighscoreHandlingStrategies
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using BalloonsPop.Common.Contracts;

    using Newtonsoft.Json;

    public class JsonHandlingStrategy : IHighscoreHandlingStrategy
    {
        private string fileName;

        public JsonHandlingStrategy(string fileName)
        {
            this.FileName = fileName;
        }

        public string FileName
        {
            get
            {
                return this.fileName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("fileName", "The name of the file cannot be null or empty.");
                }

                this.fileName = value;
            }
        }

        public void Save(IHighscoreTable table)
        {
            string json = JsonConvert.SerializeObject(table.Table.ToArray(), Formatting.Indented);
            File.WriteAllText(this.FileName, json);
        }

        public IHighscoreTable Load()
        {
            try
            {
                string json = File.ReadAllText(this.FileName);
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
