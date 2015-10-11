namespace BalloonsPop.SoundPlayer
{
    using System;
    using System.Media;
    using BalloonsPop.Common.Contracts;

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
            string filePath = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.LastIndexOf("src")) +"src\\BalloonsPop.SoundPlayer\\Sounds\\" +  soundName + ".wav";
            return filePath;
        }
    }
}
