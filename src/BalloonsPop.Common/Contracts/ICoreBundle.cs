namespace BalloonsPop.Common.Contracts
{
    public interface ICoreBundle
    {
        IPrinter Printer { get; set; }
        
        IUserInputValidator UserInputValidator { get; set; }

        IHighscoreTable HighScoreTable { get; set; }
        
        IHighscoreHandler HighscoreHandler { get; set; }

        ICommandFactory CommandFactory { get; set; }
        
        IGameModel GameModel { get; set; }
        
        IGameLogicProvider LogicProvider { get; set; }
    }
}