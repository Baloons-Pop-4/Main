namespace BaloonsPop.Engine
{
    using BaloonsPop.Common.Validators;

    public interface IEngine
    {
        void Run();

        void Initialize(IUserInterface ui, IUserInputValidator validator, ICommandFactory commandFactory, IGameModel gameModel, IGameLogicProvider gameLogicProvider);
    }
}