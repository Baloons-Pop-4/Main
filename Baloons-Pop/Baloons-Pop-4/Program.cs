using System;
using System.Collections.Generic;

using Contracts;

namespace MainProgram
{
    public class Program
    {
        public static void Main()
        {
            IEngine GameEngine = Engine.Instance;
            GameEngine.Run();
        }
    }
}
