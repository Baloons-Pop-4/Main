using BalloonsPop.Common.Contracts;
namespace BalloonsPop.Core.Commands
{
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