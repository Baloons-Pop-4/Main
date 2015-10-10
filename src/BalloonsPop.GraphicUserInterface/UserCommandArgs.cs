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
        /// Initializes a new instance of the <see cref="UserCommandArgs" /> class from command string.
        /// </summary>
        /// <param name="commandToPass">The name of current command.</param>
        public UserCommandArgs(string commandToPass)
        {
            this.commandToPass = commandToPass;
        }

        /// <summary>
        /// Gets access to the encapsulated command.
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
