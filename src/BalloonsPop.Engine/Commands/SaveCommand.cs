using BalloonsPop.Common.Contracts;
namespace BalloonsPop.Engine.Commands
{
    public class SaveCommand : ICommand
    {
        public SaveCommand()
        {
        }

        public void Execute(IContext context)
        {
            context.Memento.State = context.Game;
        }
    }
}