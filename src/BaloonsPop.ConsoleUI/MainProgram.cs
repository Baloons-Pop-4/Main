namespace BaloonsPop.ConsoleUI
{
    using System;
    using BaloonsPop.Common.Validators;
    using BaloonsPop.Engine;

    public class MainProgram
    {
        public static void Main()
        {
            var engine = Engine.Instance;

            engine.Initialize(new ConsoleUI(), UserInputValidator.GetInstance);
            engine.Run();
        }
    }
}