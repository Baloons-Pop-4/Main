namespace BalloonsPop.Common.Contracts
{
    using System;

    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);

        bool ContainsKey(string commandKey);

        void RegisterCommand(string commandKey, Func<ICommand> commandProvidingMethod);

        void UnregisterCommand(string commandKey);
    }
}