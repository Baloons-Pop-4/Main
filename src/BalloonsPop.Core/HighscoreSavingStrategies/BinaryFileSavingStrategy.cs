namespace BalloonsPop.Core
{
    using BalloonsPop.Common.Contracts;
    using System.Collections.Generic;
    using System.IO;

    public class BinaryFileSavingStrategy : IHighscoreSavingStrategy
    {
        private const string FilePath = "highscore.bin";

        public void Save(List<PlayerScore> highscoreTable)
        {
            using (Stream stream = File.Open(FilePath, FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, highscoreTable);
            }
        }
    }
}