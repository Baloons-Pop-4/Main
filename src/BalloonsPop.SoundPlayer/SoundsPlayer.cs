namespace BalloonsPop.SoundPlayer
{
    using System.Collections.Generic;
    using System.Media;

    using BalloonsPop.SoundPlayer.Contracts;

    public class SoundsPlayer : ISoundsPlayer
    {
        private IDictionary<string, ISound> sounds;
        private ISoundsLoader loader;

        public SoundsPlayer(ISoundsLoader loader)
        {
            this.sounds = new Dictionary<string, ISound>();
            this.loader = loader;
        }

        public void PlaySound(string soundName)
        {
            if (!this.sounds.ContainsKey(soundName))
            {
                this.RegisterSound(soundName);
            }

            SoundPlayer player = this.loader.CreateSoundMedia(soundName);
            player.Play();
        }

        public void RegisterSound(string soundName)
        {
            ISound newSound = new Sound(soundName);
            this.sounds.Add(soundName, newSound);
        }
    }
}
