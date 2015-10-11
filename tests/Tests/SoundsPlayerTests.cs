namespace Tests
{
    using System.Media;

    using BalloonsPop.SoundPlayer;
    
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
