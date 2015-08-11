namespace BaloonsPop
{
    using System;

    public class MainProgram
    {
        public static void Main()
        {
            var engine = Engine.Instance;
            var consoleUI = new ConsoleUI();

            engine.Initialize(consoleUI);
            engine.Run();
        }
    }
}
