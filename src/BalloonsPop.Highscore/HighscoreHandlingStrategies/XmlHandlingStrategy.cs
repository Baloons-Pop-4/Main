// <copyright file="XmlHandlingStrategy.cs" company="TelerikAcademy">
// All rights reserved. The Baloons-Pop-4 team.
// </copyright>

namespace BalloonsPop.Highscore.HighscoreHandlingStrategies
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Implements high score handling (saving and loading) in an XML format
    /// </summary>
    public class XmlHandlingStrategy : IHighscoreHandlingStrategy
    {
        /// <summary>
        /// The name of the file to be written/read to/from.
        /// </summary>
        private string fileName;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlHandlingStrategy"/> class.
        /// </summary>
        /// <param name="fileName">The name of the file to be used for loading and saving.</param>
        public XmlHandlingStrategy(string fileName)
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
        /// Saves a <see cref="IHighscoreTable"/> to a XML formatted file.
        /// </summary>
        /// <param name="table">The concrete implementation of a table.</param>
        public void Save(IHighscoreTable table)
        {
            XDocument highscoreDoc = new XDocument(
                new XElement(
                    "highscoreTable",
                    new XElement(
                        "players", 
                        from player in table.Table
                        select new XElement(
                            "player",
                                new XElement("name", player.Name),
                                new XElement("moves", player.Moves),
                                new XElement("time", player.Time)))));

            highscoreDoc.Save(this.FileName);
        }

        /// <summary>
        /// Loads a <see cref="IHighscoreTable"/> from a XML formatted file.
        /// </summary>
        /// <returns>The high score table</returns>
        public IHighscoreTable Load()
        {
            try
            {
                XDocument highscoreDoc = XDocument.Load(this.FileName);
                var playerScores = highscoreDoc.Descendants("player")
                        .Select(x => new PlayerScore(
                        x.Element("name").Value,
                        int.Parse(x.Element("moves").Value),
                        DateTime.Parse(x.Element("time").Value)))
                        .ToList();

                return new HighscoreTable(playerScores);
            }
            catch (Exception e)
            {
                // Call Logger.Warn() here -> "No highscore.xml, falling back to empty highscore table."
                return new HighscoreTable();
            }
        }
    }
}