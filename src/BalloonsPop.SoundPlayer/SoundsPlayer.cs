namespace BalloonsPop.SoundPlayer
{
    using System;
    using System.Media;
    using System.Collections.Generic;
    
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;

    /// <summary>
    /// Playes sounds based on string parameters.
    /// </summary>
    public class SoundsPlayer : ISoundsPlayer
    {
        private static readonly ILogger Logger = LogHelper.GetLogger();

        private IDictionary<string, SoundPlayer> sounds;
        private ISoundsLoader loader;

        /// <summary>
        /// Public constructor that accepts an ISoundsLoader instance that takes care of sound loading.
        /// </summary>
        /// <param name="loader"></param>
        public SoundsPlayer(ISoundsLoader loader)
        {
            this.sounds = new Dictionary<string, SoundPlayer>();
            this.loader = loader;
        }

        /// <summary>
        /// Plays the sound matching the given string. If no matching sound, throw an exception.
        /// </summary>
        /// <param name="soundName"></param>
        public void PlaySound(string soundName)
        {
            try
            {
                if (!this.sounds.ContainsKey(soundName))
                {
                    this.RegisterSound(soundName, this.loader.CreateSoundMedia(soundName));
                }

                var player = this.sounds[soundName];
                player.Play();
            }
            catch (Exception ex)
            {
                Logger.Warn("Cannot load media file.", ex);
            }
        }

        /// <summary>
        /// Caches a sound in the current instance.
        /// </summary>
        /// <param name="soundName"></param>
        /// <param name="player"></param>
        public void RegisterSound(string soundName, SoundPlayer player)
        {
            this.sounds.Add(soundName, player);
        }

        /// <summary>
        /// Returns the amount of registered sounds
        /// </summary>
        /// <returns>The amount of resitered sounds</returns>
        public int CountSounds()
        {
            return this.sounds.Count;
        }
    }
}
