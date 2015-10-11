namespace BalloonsPop.Common.Contracts
{
    using System.Media;

    public interface ISoundsPlayer
    {
        void PlaySound(string soundName);

        void RegisterSound(string soundName, SoundPlayer player);
    }
}
