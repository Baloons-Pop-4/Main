namespace Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Media;

    using BalloonsPop.SoundPlayer;

    [TestClass]
    public class SoundsPlayerTests
    {
        [TestMethod]
        public void SoundsShouldBeRegisteredProperlyToSoundsList()
        {
            SoundPlayer playerMedia = new SoundPlayer();
            SoundsLoader loader = new SoundsLoader();
            SoundsPlayer player = new SoundsPlayer(loader);

            player.RegisterSound("win", playerMedia);

            Assert.AreEqual(1, player.CountSounds());
        }
    }
}
