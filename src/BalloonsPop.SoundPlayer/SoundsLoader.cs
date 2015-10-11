namespace BalloonsPop.SoundPlayer
{
    using System;
    using System.Media;
    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Provides sound loading for the app.
    /// </summary>
    public class SoundsLoader : ISoundsLoader
    {
        /// <summary>
        /// Provides System.Media.SoundPlayers loaded with the sound matching the provided string.
        /// </summary>
        /// <param name="soundName"></param>
        /// <returns>A new SoundPlayer object</returns>
        public SoundPlayer CreateSoundMedia(string soundName)
        {
            string path = this.BuildFilePath(soundName);
            var player = new SoundPlayer(path);
            return player;
        }

        private string BuildFilePath(string soundName)
        {
            string filePath = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.LastIndexOf("src")) + "src\\BalloonsPop.SoundPlayer\\Sounds\\" + soundName + ".wav";
            return filePath;
        }
    }
}
