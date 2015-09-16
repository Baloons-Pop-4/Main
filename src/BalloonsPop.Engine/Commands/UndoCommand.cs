namespace BalloonsPop.Engine.Commands
{
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Engine.Memento;


    public class UndoCommand : GameCommand
    {
        private IMemento<IGameModel> memento;

        public UndoCommand(IGameModel gameModel, IMemento<IGameModel> memento)
            : base(gameModel)
        {
            this.memento = memento;
        }

        public override void Execute()
        {
            this.gameModel.Field = memento.State.Field;
            System.Console.WriteLine("mirishi");
        }
    }
}
