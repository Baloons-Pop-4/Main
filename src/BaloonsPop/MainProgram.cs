namespace BaloonsPop
{
    using System;
    
    using Engine;
    using Validations;
    using UserInterfaces;

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