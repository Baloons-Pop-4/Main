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
        /// Initializes a new instance of the <see cref="PlaySoundCommand" /> class.
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