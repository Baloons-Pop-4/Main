namespace BalloonsPop.Common.Contracts
{
    public interface IContext
    {
        IGameModel Game { get; }

        IGameLogicProvider LogicProvider { get; }

        IPrinter Printer { get; }

        IStateSaver<IGameModel> Memento { get; }

        IHighscoreTable HighscoreTable { get; }

        IHighscoreHandlingStrategy HighscoreHandling { get; }

        string Message { get; set; }

        string PlayerName { get; set; }

        int UserRow { get; set; }

        int UserCol { get; set; }
    }
}
