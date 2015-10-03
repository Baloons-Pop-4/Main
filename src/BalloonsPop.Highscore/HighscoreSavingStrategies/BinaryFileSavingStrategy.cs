namespace BalloonsPop.Highscore
{
    using System.Collections.Generic;
    using System.IO;

    using BalloonsPop.Common.Contracts;

    public class BinaryFileSavingStrategy : IHighscoreSavingStrategy
    {
        private const string FilePath = "highscore.bin";

        public void Save(List<IPlayerScore> highscoreTable)
        {
            using (Stream stream = File.Open(FilePath, FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, highscoreTable);
            }
        }
    }
}