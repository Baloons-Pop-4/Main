namespace BalloonsPop.SoundPlayer
{
    using System;
    using System.Collections.Generic;
    using System.Media;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;

    using BalloonsPop.SoundPlayer.Contracts;

    public class SoundsPlayer : ISoundsPlayer
    {
        private IDictionary<string, ISound> sounds;
        private ISoundsLoader loader;
        private static readonly ILogger Logger = LogHelper.GetLogger();

        public SoundsPlayer(ISoundsLoader loader)
        {
            this.sounds = new Dictionary<string, ISound>();
            this.loader = loader;
        }

        public void PlaySound(string soundName)
        {
            try
            {
                if (!this.sounds.ContainsKey(soundName))
                {
                    this.RegisterSound(soundName);
                }

                SoundPlayer player = this.loader.CreateSoundMedia(soundName);
                player.Play();
            }
            catch (Exception ex)
            {
                Logger.Warn("Cannot load media file.", ex);
            }

        }

        public void RegisterSound(string soundName)
        {
            ISound newSound = new Sound(soundName);
            this.sounds.Add(soundName, newSound);
        }
    }
}
