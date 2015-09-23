namespace BalloonsPop.GraphicUserInterface
{
    using System;

    public interface IEventEngine
    {
        void HandleUserInput(object sender, EventArgs e);
    }
}