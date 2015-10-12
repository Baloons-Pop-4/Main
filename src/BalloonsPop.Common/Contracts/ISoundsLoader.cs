namespace BalloonsPop.Common.Contracts
{
    using System.Media;

    /// <summary>
    /// Abstraction of loading sounds files from the file system.
    /// </summary>
    public interface ISoundsLoader
    {
        /// <summary>
        /// Defines abstract loading according to a provided string parameter.
        /// </summary>
        /// <param name="soundName"></param>
        /// <returns>A loaded instance of System.Media.SoundPlayer.</returns>
        SoundPlayer CreateSoundMedia(string soundName);
    }
}
