namespace BaloonsPop.ConsoleUI
{
    using System;
    using BaloonsPop.Common.Validators;
    using BaloonsPop.Engine;
    using BaloonsPop.Engine.Commands;

    public class MainProgram
    {
        public static void Main()
        {
            var engine = Engine.Instance;

            engine.Initialize(new ConsoleUI(), UserInputValidator.GetInstance, new CommandFactory());
            engine.Run();
        }
    }
}