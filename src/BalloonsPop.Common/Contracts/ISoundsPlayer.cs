namespace BalloonsPop.Common.Contracts
{
    using System.Media;

    /// <summary>
    /// Defines the outline of a soundplayer.
    /// </summary>
    public interface ISoundsPlayer
    {
        /// <summary>
        /// Loads and plays a sound according the string parameter.
        /// </summary>
        /// <param name="soundName"></param>
        void PlaySound(string soundName);

        /// <summary>
        /// Registers a foreign sound in the player, storing it there for later use.
        /// </summary>
        /// <param name="soundName">The key of the sound file.</param>
        /// <param name="player">The loaded player which will mathc the key.</param>
        void RegisterSound(string soundName, SoundPlayer player);
    }
}
