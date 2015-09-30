namespace BalloonsPop.Common.Gadgets
{
    using System;
    using System.IO;
    using System.Media;

    public class SoundsPlayer
    {
        const string oldPath = "BalloonsPop.ConsoleUI\\bin\\Debug";

        private SoundPlayer sound;

        public void PlaySound(string soundName)
        {
            string soundPath = BuildPath(soundName);

            sound = new SoundPlayer(Environment.CurrentDirectory.Replace(oldPath, soundPath));

            sound.Play();
        }

        public string BuildPath(string soundPath)
        {
            string path = "Sounds/" + soundPath + ".wav";

            return path;
        }
    }
}
