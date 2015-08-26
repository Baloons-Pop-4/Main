using BalloonsPop.Common.Contracts;
using BalloonsPop.Engine.Memento;
namespace BalloonsPop.Engine.Commands
{
    public class SaveCommand : GameCommand
    {
        private IMemento<IGameModel> memento;

        public SaveCommand(IGameModel gameModel, IMemento<IGameModel> memento)
            :base(gameModel)
        {
            this.memento = memento;
        }

        public override void Execute()
        {
            this.memento.State = this.gameModel;
        }
    }
}
