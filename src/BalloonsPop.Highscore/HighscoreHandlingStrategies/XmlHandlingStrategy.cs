namespace BalloonsPop.Highscore.HighscoreHandlingStrategies
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    using BalloonsPop.Common.Contracts;

    public class XmlHandlingStrategy : IHighscoreHandlingStrategy
    {
        private string fileName;

        public XmlHandlingStrategy(string fileName)
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