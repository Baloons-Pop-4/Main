namespace BalloonsPop.SoundPlayer
{
    using System;
    using System.Media;
    using System.Collections.Generic;
    
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;

    public class SoundsPlayer : ISoundsPlayer
    {
        private static readonly ILogger Logger = LogHelper.GetLogger();

        private IDictionary<string, SoundPlayer> sounds;
        private ISoundsLoader loader;

        public SoundsPlayer(ISoundsLoader loader)
        {
            this.sounds = new Dictionary<string, SoundPlayer>();
            this.loader = loader;
        }

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

        public void RegisterSound(string soundName, SoundPlayer player)
        {
            this.sounds.Add(soundName, player);
        }
    }
}
