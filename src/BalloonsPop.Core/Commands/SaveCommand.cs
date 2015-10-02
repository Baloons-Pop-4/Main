namespace BalloonsPop.Core.Commands
{
    using BalloonsPop.Common.Contracts;

    public class SaveCommand : ICommand
    {
        public SaveCommand()
        {
        }

        public void Execute(IContext context)
        {
            context.Memento.SaveState(context.Game);
        }
    }
}