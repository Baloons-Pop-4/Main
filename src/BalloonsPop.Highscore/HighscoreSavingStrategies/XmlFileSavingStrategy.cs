namespace BalloonsPop.Highscore
{
    using BalloonsPop.Common.Contracts;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Linq;
    using System.Linq;

    public class XmlFileSavingStrategy : IHighscoreSavingStrategy
    {
        private const string FilePath = "highscore.xml";
         
        public void Save(List<IPlayerScore> highscoreTable)
        {
            XDocument xDocument = new XDocument(
                new XElement("HighscoreTable",
                    new XElement("Players", 
                        from player in highscoreTable
                        select new XElement("Player",
                            new XAttribute("Name", player.Name),
                            new XAttribute("Moves", player.Moves),
                            new XAttribute("Time", player.Time)
                        )
                    )));

            xDocument.Save(FilePath);
        }
    }
}
