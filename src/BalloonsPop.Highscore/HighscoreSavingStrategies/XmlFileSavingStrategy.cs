namespace BalloonsPop.Highscore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    using BalloonsPop.Common.Contracts;

    public class XmlFileSavingStrategy : IHighscoreSavingStrategy
    {
        private const string FilePath = "highscore.xml";
         
        public void Save(List<IPlayerScore> highscoreTable)
        {
            XDocument highscoreDoc = new XDocument(
                new XElement(
                    "HighscoreTable",
                    new XElement(
                        "Players", 
                        from player in highscoreTable
                        select new XElement(
                            "Player",
                                new XAttribute("Name", player.Name),
                                new XAttribute("Moves", player.Moves),
                                new XAttribute("Time", player.Time)))));

            highscoreDoc.Save(FilePath);
        }
    }
}
