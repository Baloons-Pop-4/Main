namespace BalloonsPop.Common.Contracts
{
    public interface IContext
    {
        IGameModel Game { get; }

        IGameLogicProvider LogicProvider { get; }

        IPrinter Printer { get; }

        IMemento<IGameModel> Memento { get; }

        IHighscoreTable HighscoreTable { get; }

        string Message { get; set; }

        int UserRow { get; set; }

        int UserCol { get; set; }
    }
}
