namespace BalloonsPop.Core
{
    using BalloonsPop.Common.Contracts;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    public class XmlFileSavingStrategy : IHighscoreSavingStrategy
    {
        private const string FilePath = "highscore.xml";
         
        public void Save(List<PlayerScore> highscoreTable)
        {
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(List<PlayerScore>));
                writer = new StreamWriter(XmlFileSavingStrategy.FilePath, false);
                serializer.Serialize(writer, highscoreTable);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
    }
}
