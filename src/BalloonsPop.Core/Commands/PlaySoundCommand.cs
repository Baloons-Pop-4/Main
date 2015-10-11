namespace BalloonsPop.Core.Commands
{
    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Implements command to play a sound
    /// </summary>
    public class PlaySoundCommand : ICommand
    {
        private string sound;

        /// <summary>
        /// Plays a specified sound
        /// </summary>
        /// <param name="sound"></param>
        public PlaySoundCommand(string sound)
        {
            this.sound = sound;
        }

        /// <summary>
        /// Executes the PlaySoundCommand
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IContext context)
        {
            context.Orchestra.PlaySound(this.sound);
        }
    }
}