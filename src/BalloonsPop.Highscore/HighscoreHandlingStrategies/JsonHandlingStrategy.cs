// <copyright file="JsonHandlingStrategy.cs" company="TelerikAcademy">
// All rights reserved. The Baloons-Pop-4 team.
// </copyright>

namespace BalloonsPop.Highscore.HighscoreHandlingStrategies
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements high score handling (saving and loading) in a JSON format
    /// </summary>
    public class JsonHandlingStrategy : IHighscoreHandlingStrategy
    {
        private static readonly ILogger Logger = LogHelper.GetLogger();
        
        /// <summary>
        /// The name of the file to be written/read to/from.
        /// </summary>
        private string fileName;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonHandlingStrategy"/> class.
        /// </summary>
        /// <param name="fileName">The name of the file to be used for loading and saving.</param>
        public JsonHandlingStrategy(string fileName)
        {
            this.FileName = fileName;
        }

        /// <summary>
        /// Gets the file name which is used for loading and saving the high score.
        /// </summary>
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

        /// <summary>
        /// Saves a <see cref="IHighscoreTable"/> to a JSON formatted file.
        /// </summary>
        /// <param name="table">The concrete implementation of a table.</param>
        public void Save(IHighscoreTable table)
        {
            string json = JsonConvert.SerializeObject(table.Table.ToArray(), Formatting.Indented);
            try
            {
                File.WriteAllText(this.FileName, json);
            }
            catch (Exception ex)
            {
                Logger.Error("Cannot save highscore in json file.", ex);
                throw;
            }
        }

        /// <summary>
        /// Loads a <see cref="IHighscoreTable"/> from a JSON formatted file.
        /// </summary>
        /// <returns>The high score table</returns>
        public IHighscoreTable Load()
        {
            try
            {
                string json = File.ReadAllText(this.FileName);
                var playerScores = JsonConvert.DeserializeObject<List<PlayerScore>>(json);
                return new HighscoreTable(playerScores);
            }
            catch (Exception)
            {
                Logger.Warn("No highscore.json, falling back to empty highscore table.");
                return new HighscoreTable();
            }
        }
    }
}
