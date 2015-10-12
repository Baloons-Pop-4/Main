namespace BalloonsPop.Common.Contracts
{
    using System;

    /// <summary>
    /// Interface for command provider.
    /// </summary>
    public interface ICommandFactory
    {
        /// <summary>
        /// Defines an abstract way to create a command according to a provided string parameter.
        /// </summary>
        /// <param name="commandName">The command key.</param>
        /// <returns>Concrete type of command as abstract type ICommand.</returns>
        ICommand CreateCommand(string commandName);

        /// <summary>
        /// Defines an abstract way to verify whether a given command can be created from the implementing factory.
        /// </summary>
        /// <param name="commandKey">The command key.</param>
        /// <returns>True if the factory can create a command with the provided key, false otherwise.</returns>
        bool ContainsKey(string commandKey);

        /// <summary>
        /// Provides a method of creating the specified command to the factory.
        /// </summary>
        /// <param name="commandKey">The key with which the command can be created after successful register.</param>
        /// <param name="commandProvidingMethod">The method which will be used to provide the command.</param>
        void RegisterCommand(string commandKey, Func<ICommand> commandProvidingMethod);

        /// <summary>
        /// Removes a key and the respective command from the factory.
        /// </summary>
        /// <param name="commandKey">The key of the command to remove.</param>
        void UnregisterCommand(string commandKey);
    }
}