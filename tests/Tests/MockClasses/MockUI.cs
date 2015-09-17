using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BalloonsPop.Common.Contracts;

namespace Tests.MockClasses
{
    public class MockPrinter : IPrinter
    {
        public readonly Dictionary<string, int> methodCallCounts = new Dictionary<string, int>()
        {
            {"message", 0},
            {"field", 0},
            {"highscore", 0}
        };

        public MockPrinter()
        {
        }

        public void PrintMessage(string message)
        {
            this.methodCallCounts["message"]++;
        }

        public void PrintField(byte[,] matrix)
        {
            this.methodCallCounts["field"]++;
        }

        public void PrintHighscore(string[,] highscore)
        {
            this.methodCallCounts["highscore"]++;
        }
    }
}
