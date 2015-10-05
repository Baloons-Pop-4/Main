namespace BalloonsPop.Common.Contracts
{
    public interface ICoreBundle
    {
        IPrinter Printer { get; set; }
        
        IUserInputValidator UserInputValidator { get; set; }

        IHighscoreTable HighScoreTable { get; set; }

        IHighscoreHandlingStrategy HighscoreHandlingStrategy { get; set; }

        ICommandFactory CommandFactory { get; set; }
        
        IGameModel GameModel { get; set; }
        
        IGameLogicProvider LogicProvider { get; set; }
    }
}