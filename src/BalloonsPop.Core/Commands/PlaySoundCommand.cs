namespace BalloonsPop.Core.Commands
{
    using BalloonsPop.Common.Contracts;

    public class PlaySoundCommand : ICommand
    {
        private string sound;

        public PlaySoundCommand(string sound)
        {
            this.sound = sound;
        }

        public void Execute(IContext context)
        {
            context.Orchestra.PlaySound(sound);
        }
    }
}