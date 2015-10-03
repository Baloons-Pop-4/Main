namespace BalloonsPop.Highscore.HighscoreHandlingStrategies
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    using BalloonsPop.Common.Contracts;

    public class XmlHandlingStrategy : IHighscoreHandlingStrategy
    {

        private const string FilePath = "highscore.xml";
         
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

            highscoreDoc.Save(FilePath);
        }

        public IHighscoreTable Load()
        {
            try
            {
                XDocument highscoreDoc = XDocument.Load(FilePath);
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
                Console.WriteLine(e);
                // Call Logger.Warn() here -> "No highscore.xml, falling back to empty highscore table."
                return new HighscoreTable();
            }
        }
    }
}