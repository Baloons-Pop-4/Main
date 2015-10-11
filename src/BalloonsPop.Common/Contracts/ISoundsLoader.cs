namespace BalloonsPop.Common.Contracts
{
    using System.Media;

    public interface ISoundsLoader
    {
        SoundPlayer CreateSoundMedia(string soundName);
    }
}
