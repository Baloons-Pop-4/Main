namespace BalloonsPop.GraphicUserInterface
{
    using System;

    public class ClickEventArgs : EventArgs
    {
        private readonly string commandToPass;

        public ClickEventArgs(string commandToPass)
        {
            this.commandToPass = commandToPass;
        }

        public string CommandToPass
        {
            get
            {
                return this.commandToPass;
            }
        }
    }
}
