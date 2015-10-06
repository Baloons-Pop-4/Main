namespace BalloonsPop.GraphicUserInterface
{
    using System;

    /// <summary>
    /// Event arguments that encapsulate a command as a string.
    /// </summary>
    public class UserCommandArgs : EventArgs
    {
        private readonly string commandToPass;

        /// <summary>
        /// Constructor for creation from command string.
        /// </summary>
        /// <param name="commandToPass"></param>
        public UserCommandArgs(string commandToPass)
        {
            this.commandToPass = commandToPass;
        }

        /// <summary>
        /// Provides read-only access to the encapsulated command.
        /// </summary>
        public string CommandToPass
        {
            get
            {
                return this.commandToPass;
            }
        }
    }
}
