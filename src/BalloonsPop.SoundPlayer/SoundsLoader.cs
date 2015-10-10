namespace BalloonsPop.SoundPlayer
{
    using System.Media;

    using BalloonsPop.SoundPlayer.Contracts;

    public class SoundsLoader : ISoundsLoader
    {
        public SoundPlayer CreateSoundMedia(string soundName)
        {
            string path = this.BuildFilePath(soundName);
            var player = new SoundPlayer(path);
            return player;
        }

        private string BuildFilePath(string soundName)
        {
            string filePath = "../../Sounds/" + soundName + ".wav";
            return filePath;
        }
    }
}
