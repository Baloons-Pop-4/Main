namespace BalloonsPop.GraphicUserInterface.Commands
{
    using System.Windows;
    using BalloonsPop.Common.Contracts;

    public class WpfExitCommand : ICommand
    {
        public void Execute(IContext context)
        {
            Application.Current.Shutdown(348944);
        }
    }
}
