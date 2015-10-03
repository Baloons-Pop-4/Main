namespace BalloonsPop.Highscore.HighscoreHandlingStrategies
{
    using System;
    using System.Collections.Generic;
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

        // TODO: FIX THIS METHOD.
        public IHighscoreTable Load()
        {
            // var PlayerScore = kernel.Get<IPlayerScore>() ?

            XDocument highscoreDoc = XDocument.Load(FilePath);
            var playerScores = highscoreDoc.Descendants("players")
                    .Select(x => new PlayerScore(
                    x.Element("name").Value,
                    int.Parse(x.Element("moves").Value),
                    DateTime.Parse(x.Element("time").Value)))
                    .ToList();

            // return new HighScoreTable(playerScores)
            return new HighscoreTable();
        }
    }
}