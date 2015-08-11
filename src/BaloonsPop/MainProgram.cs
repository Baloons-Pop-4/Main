namespace BaloonsPop
{
    using System;
    using Validations;
    using Engine;

    public class MainProgram
    {
        public static void Main()
        {
            var engine = Engine.Instance;

            engine.Initialize(new ConsoleUI(), ValidationProvider.InputValidator);
            engine.Run();
        }
    }
}