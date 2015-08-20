namespace BaloonsPop.GraphicUserInterface
{
    using System;

    public class ClickEventArgs : EventArgs
    {
        private string commandToPass;

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
