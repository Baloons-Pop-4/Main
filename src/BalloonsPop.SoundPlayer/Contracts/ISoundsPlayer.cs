namespace BalloonsPop.SoundPlayer.Contracts
{
    using System.Media;

    internal interface ISoundsPlayer
    {
        void PlaySound(string soundName);

        void RegisterSound(string soundName);
    }
}
