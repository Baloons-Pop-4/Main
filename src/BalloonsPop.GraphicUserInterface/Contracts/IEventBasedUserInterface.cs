namespace BalloonsPop.GraphicUserInterface.Contracts
{
    using System;
    using System.Windows.Controls;
    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Inherits IPrinter and provides contract for a wpf use interface that is compatible with the EngineCore class.
    /// </summary>
    public interface IEventBasedUserInterface : IPrinter
    {
        /// <summary>
        /// Event which delegates the a user action interpreted as a command.
        /// </summary>
        event EventHandler RaiseCommand;

        /// <summary>
        /// Event which delegates the change of the user name to the engine.
        /// </summary>
        event TextChangedEventHandler ChangedUserName;

        /// <summary>
        /// Method that displays the applications graphic interface to the user.
        /// </summary>
        void Show();
    }
}
