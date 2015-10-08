namespace BalloonsPop.SoundPlayer
{
    using BalloonsPop.SoundPlayer.Contracts;

    public class Sound : ISound
    {
        public Sound(string fileName)
        {
            this.FileName = fileName;
        }

        public string FileName { get; private set; }
    }
}
